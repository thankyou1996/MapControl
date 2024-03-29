﻿/**
         * @fileoverview Marker Manager 标注管理器
        * 主入口类是<a href="symbols/BMapLib.MarkerManager.html">MarkerManager</a>，
        * 基于Baidu Map API 1.2。*
        * @author Baidu Map Api Group
        * @version 1.2
        */
/** @namespace BMap的所有library类均放在BMapLib命名空间下**/
var BMapLib = window.BMapLib = BMapLib || {};
(function () {
    var T,
        baidu = T = baidu || { version: "1.5.1" };
    baidu.guid = "$BAIDU$";
    (function () {
        window[baidu.guid] = window[baidu.guid] || {};
        baidu.object = baidu.object || {};
        baidu.extend =
            baidu.object.extend = function (target, source) {
                for (var p in source) {
                    if (source.hasOwnProperty(p)) {
                        target[p] = source[p];
                    }
                }

                return target;
            };
        T.undope = true;
    })();
    /**
     * @exports MarkerManager as BMapLib.MarkerManager
     */

    var MarkerManager =
        /**
         * MarkerManger类的构造函数
         * @class MarkerManager <b>入口</b>。
         * 实例化该类后，可调用addMarkers,show,hide等方法，控制marker。
         * 请注意，此类比较适用于以下情况：
         * 大量marker分布到不同的zoom级别中，比如：18级的时候显示100个marker，15级的时候显示另外的100个marker
         * @constructor
             * @param {Map} map Baidu map的实例对象.
             * @param {Json Object} opts 可选的输入参数，非必填项。可输入选项包括：<br />
             * {<br />"<b>borderPadding</b>" : {Number} 当前viewport额外的padding，落在这个padding中的marker会被添加到地图上，即使他们不是完全可见的。
             * <br />"<b>maxZoom</b>" : {Number} 设置需要marker manager需要监视的最大的zoom，如果没有给出，默认为地图的最大的zoom。.
             *<br />
             * }<br />.
             * @example <b>参考示例：</b><br />
             * var mgr = new BMapLib.MarkerManager(map,{borderPadding: padding,maxZoom: 18,trackMarkers: true});
         */
        BMapLib.MarkerManager = function (map, opts) {
            this._opts = opts || {};
            this._map = map;
            this._zoom = map.getZoom();
            //用于存放添加的marker数组
            this._numMarkers = [];

            if (typeof opts.maxZoom === 'number') {
                this._opts.maxZoom = this._opts.maxZoom;
            } else {
                this._opts.maxZoom = 19;
            }
            if (typeof opts.borderPadding === 'number') {
                this._opts.borderPadding = opts.borderPadding;
            } else {
                this._opts.borderPadding = 0;
            }

            var me = this;
            //绑定zoomend事件
            this._map.addEventListener("zoomend", function () {
                //me._visible && me._showMarkers();
                me._showMarkers();
            });
            //绑定dragend事件
            this._map.addEventListener("dragend", function () {
                //me._visible && me._showMarkers();
                me._showMarkers();
            });
        }
    /**
     * 添加单个marker
     * @param {Marker} marker 要添加的marker
     * @param {Number} minZoom 当地图缩放到小于此zoom的时候，marker不会加载到地图上
     * @param {Number} maxZoom 当地图缩放到大于此zoom的时候，marker不会加载到地图上
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.addMarker(marker,4,15);
     */
    MarkerManager.prototype.addMarker = function (marker, markinfo, minZoom, maxZoom) {
        minZoom = minZoom && minZoom > 0 ? minZoom : 1;
        maxZoom = maxZoom && maxZoom <= 19 ? maxZoom : this._opts.maxZoom;
        marker.minZoom = minZoom;
        marker.maxZoom = maxZoom;
        marker.bAdded = false;
        marker.setTitle(markinfo);
        this._numMarkers.push(marker);
    }
    /**
     * 批量添加marker
     * @param {Array} markers 要添加的marker数组
     * @param {Number} minZoom 当地图缩放到小于此zoom的时候，marker不会加载到地图上
     * @param {Number} maxZoom 当地图缩放到大于此zoom的时候，marker不会加载到地图上
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.addMarker(markers,4,15);
     */
    MarkerManager.prototype.addMarkers = function (markers, markersInfo, minZoom, maxZoom) {
        var len = markers.length,
            me = this;
        for (var i = len; i--;) {
            this.addMarker(markers[i], markersInfo[i], minZoom, maxZoom);
        }
    }
    /**
     * 从manager跟地图中，移除marker（如果它现在可见）
     * @param {Marker} marker 要删除的marker
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.removeMarker(Marker);
     */
    MarkerManager.prototype.removeMarker = function (marker) {
        if (marker instanceof BMap.Marker) {
            //移除地图上的marker
            this._map.removeOverlay(marker);
            //移除markerManager中的marker
            this._removeMarkerFromArray(marker);
        }
    }
    /**
     * 返回此zoom下可见marker的数量
     * @param {Number} zoom 地图缩放级别
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.getMarkerCount(15);
     */
    MarkerManager.prototype.getMarkerCount = function (zoom) {
        var len = this._numMarkers.length,
            t = this._numMarkers,
            count = 0;
        for (var i = len; i--;) {
            count = t[i].bInBounds ? ((t[i].minZoom <= zoom && t[i].maxZoom >= zoom) ? ++count : count) : count;
        }
        //如果隐藏掉所有marker则marker数量为0
        return this._visible ? count : 0;
    }
    /**
     * 显示marker,此方法只是控制css样式中的display的值。
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.show();
     */
    MarkerManager.prototype.show = function () {
        var num = this._numMarkers.length;
        for (var i = num; i--;) {
            //将视野中的marker显示
            this._numMarkers[i].bInBounds && this._numMarkers[i].show();
        }
        this._visible = true;
    }
    /**
     * 隐藏marker，此方法只是控制css样式中的display的值。
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.hide();
     */
    MarkerManager.prototype.hide = function () {
        var num = this._numMarkers.length;
        for (var i = num; i--;) {
            this._numMarkers[i].bInBounds && this._numMarkers[i].hide();
        }
        this._visible = false;
    }
    /**
     * 显示或者隐藏marker
     * @param {Marker} marker 要删除的marker
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.toggle(marker,4,15);
     */
    MarkerManager.prototype.toggle = function () {
        this._visible ? this.hide() : this.show();
    }
    /**
     * 显示地图上的marker
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.showMarkers();
     */
    MarkerManager.prototype.showMarkers = function () {
        this._visible = true;
        this._showMarkers();
    }
    /**
     * 移除在manager中的所有marker,并清空。
     * @param none
     * @return none
     *
     * @example <b>参考示例：</b><br />
     * mgr.clearMarkers();
     */
    MarkerManager.prototype.clearMarkers = function () {
        var len = this._numMarkers.length;
        for (var i = len; i--;) {
            this._numMarkers[i].bInBounds && this._map.removeOverlay(this._numMarkers[i]);
        }
        this._numMarkers.length = 0;
    }
    MarkerManager.prototype.getMarker = function (id) {
        return this.getMarker(id);
    }
    //重置动画效果
    MarkerManager.prototype.resetAnimation = function () {
        this.resetAnimation();
    }
    baidu.object.extend(MarkerManager.prototype, {
        _showMarkers: function () {
            var num = this._numMarkers.length,
                curZoom = this._map.getZoom(),
                t = this._numMarkers,
                curBounds = this._getRealBounds();
            for (var i = num; i--;) {
                //在可视区域内 && 当前zoom符合marker的显示条件
                if (curBounds.containsPoint(t[i].getPosition()) && curZoom >= t[i].minZoom && curZoom <= t[i].maxZoom) {
                    t[i].bInBounds = true;
                    //没有被添加到地图
                    if (!t[i].bAdded) {
                        this._map.addOverlay(t[i]);
                        !this._visible && t[i].hide();
                        t[i].bAdded = true;
                    } else {
                        //显示marker
                        this._visible && t[i].show();
                    }
                } else if (t[i].bAdded) {
                    // 当前地图zoom小于marker的最小zoom或者大于最大zoom,并且已经被添加到地图上。就将此marker隐藏
                    t[i].bInBounds = false;
                    //this._map.removeOverlay(t[i]);
                    t[i].hide();
                }
            }
        },
        /**
         * 得到实际的bound范围
         * @return none
         */
        _getRealBounds: function () {
            var curBounds = this._map.getBounds(),
                southWest = this._map.pointToPixel(curBounds.getSouthWest()),
                northEast = this._map.pointToPixel(curBounds.getNorthEast()),
                extendSW = {
                    x: southWest.x - this._opts.borderPadding,
                    y: southWest.y + this._opts.borderPadding
                },
                extendNE = {
                    x: northEast.x + this._opts.borderPadding,
                    y: northEast.y - this._opts.borderPadding
                },
                extendSwPoint = this._map.pixelToPoint(extendSW),
                extendNePoint = this._map.pixelToPoint(extendNE);
            return new BMap.Bounds(extendSwPoint, extendNePoint);
        },
        /**
         * 从数组中删除marker
         * @param {Marker} marker 要删除的marker
         * @return {String} 被删除的marker的数量
         */
        _removeMarkerFromArray: function (marker) {
            var num = this._numMarkers.length,
                i = num,
                shift = 0;
            for (i = num; i--;) {
                if (marker === this._numMarkers[i]) {
                    this._numMarkers.splice(i--, 1)
                    shift++;
                }
            }
            return shift;
        }
    });

    var PoloiceRoom_Gray = new BMap.Icon("OnlineMapIcon/PoloiceRoom_Gray.png", new BMap.Size(40, 40), {
        imageOffset: new BMap.Size(0, 0)
    });
    var PoloiceRoom_Blue = new BMap.Icon("OnlineMapIcon/PoloiceRoom_Blue.png", new BMap.Size(40, 40), {
        imageOffset: new BMap.Size(0, 0)
    });
    var c = BMapLib.Manager = function (f) {
        this._map = f;
        this._numMarkers = [];
        var d = this;
        this._map.addEventListener("zoomend", function () {
            d._showMarkers()
        });
        this._map.addEventListener("dragend", function () {
            d._showMarkers()
        })
    };
    c.prototype.addMarker = function (e, m, n) {
        e.bAdded = false;
        var icon = new BMap.Icon(n, new BMap.Size(32, 32), { anchor: new BMap.Size(16, 32), imageOffset: new BMap.Size(0, 0) });
        e.setIcon(icon);
        if (m != "")
            e.setLabel(new BMap.Label(m, {
                offset: new BMap.Size(40, 0)
            }));
        this._numMarkers.push(e);
    };
    c.prototype.addMarkers = function (h, x, y) {
        var d = h.length;
        for (var f = d; f--;) {
            this.addMarker(h[f], x[f], y[f])
        }
    };
    c.prototype.getMarker = function (id) {

        for (var i = 0; i < this._numMarkers.length; i++)  {
            if (this._numMarkers[i].id == id) {
                return this._numMarkers[i];
            }
        }
    };
    c.prototype.resetAnimation = function () {
        for (var i = 0; i < this._numMarkers.length; i++) {
            this._numMarkers[i].setAnimation(null);
        }
    }
    c.prototype.removeMarker = function (d) {
        if (d instanceof BMap.Marker) {
            this._map.removeOverlay(d);
            this._removeMarkerFromArray(d)
        }
    };
    c.prototype.show = function () {
        var d = this._numMarkers.length;
        for (var e = d; e--;) {
            this._numMarkers[e].bInBounds && this._numMarkers[e].show()
        }
        this._visible = true
    };
    c.prototype.hide = function () {
        var d = this._numMarkers.length;
        for (var e = d; e--;) {
            this._numMarkers[e].bInBounds && this._numMarkers[e].hide()
        }
        this._visible = false
    };
    c.prototype.toggle = function () {
        this._visible ? this.hide() : this.show()
    };
    c.prototype.showMarkers = function () {
        this._visible = true;
        var d = this._numMarkers.length,
            f = this._numMarkers;
        for (var e = d; e--;) {
            f[e].bInBounds = true;
            if (!f[e].bAdded) {
                this._map.addOverlay(f[e]);
                !this._visible && f[e].hide();
                f[e].bAdded = true
            } else {
                this._visible && f[e].show()
            }
        }
    };
    c.prototype.clearMarkers = function () {
        var d = this._numMarkers.length;
        for (var e = d; e--;) {
            this._map.removeOverlay(this._numMarkers[e])
        }
        this._numMarkers.length = 0
    };
    c.prototype.selectAddr = function (a, b, i) {
        var d = this._numMarkers.length;
        for (var e = d; e--;) {
            var p = this._numMarkers[e].getPosition();
            if (p.lng == a && p.lat == b) {
                if (i == "1") {
                    this._numMarkers[e].setIcon(PoloiceRoom_Gray);
                }
                else {
                    this._numMarkers[e].setIcon(PoloiceRoom_Blue);
                }
            }
        }
    };
    c.prototype.removeAddr = function (lng, lat) {
        var d = this._numMarkers.length;

        for (var e = d; e--;) {
            var p = this._numMarkers[e].getPosition();

            if (p.lng == lng && p.lat == lat) {

                this._map.removeOverlay(this._numMarkers[e])
                return;
            }
        }
    };
    baidu.object.extend(c.prototype, {
        _showMarkers: function () {
            var d = this._numMarkers.length,
                f = this._numMarkers,
                g = this._map.getBounds();
            for (var e = d; e--;) {
                if (g.containsPoint(f[e].getPosition())) {
                    f[e].bInBounds = true;
                    if (!f[e].bAdded) {
                        this._map.addOverlay(f[e]);
                        !this._visible && f[e].hide();
                        f[e].bAdded = true
                    } else {
                        this._visible && f[e].show()
                    }
                } else {
                    if (f[e].bAdded) {
                        f[e].bInBounds = false;
                        f[e].hide()
                    }
                }
            }
        },
        _removeMarkerFromArray: function (e) {
            var f = this._numMarkers.length,
                g = f,
                d = 0;
            for (g = f; g--;) {
                if (e === this._numMarkers[g]) {
                    this._numMarkers.splice(g--, 1);
                    d++
                }
            }
            return d
        }
    });
})();