
//170407 设置双击是否启用放大缩小功能
function SetEnableDoubleClickZoom(bolSetValue) {
    if (bolSetValue) {
        map.enableDoubleClickZoom();
    }
    else {
        map.disableDoubleClickZoom();
    }
}
//设置地图等级
function SetMapLevel(intLevel)
{
    map.setZoom(intLevel);
}

//设置标注点
function DisplayMarker(lon, lat, strIconFilePath) {
    var p = new BMap.Point(lon, lat);
    var m = new BMap.Marker(p);
    mgr.addMarker(m, '', strIconFilePath);
    mgr.showMarkers();
}

function SetMarkerANIMATION_BOUNCE(id) {
    var vv = mgr.getMarker(id);
    if (vv != undefined) {
        mgr.resetAnimation();
        vv.setAnimation(BMAP_ANIMATION_BOUNCE);
    }
}


//设置中心点 180103
function SetMapCenter(lon, lat) {
    var point = new BMap.Point(lon, lat);
    map.setCenter(point);
    mgr._showMarkers();
}


//右键事件
function MarkerRightClick(m, e) {
    alert(1);
    var p = m.getPosition();       //获取marker的位置
    alert("marker的位置是" + p.lng + "," + p.lat);   
}

//显示设备标注点
function DisplayMarker1(lon, lat, strTitle, strIconFilePath, strclickInfo) {
    var p = new BMap.Point(lon, lat);
    var m = new BMap.Marker(p);
    m.id = strclickInfo;
    m.addEventListener("click", function (){ 
        //console.log(strclickInfo);
        //map.removeOverlay(marker2);
        window.external.MarkerClick(strclickInfo);
    });
    m.addEventListener("rightclick", function (){ 
        //console.log(strclickInfo);
        //map.removeOverlay(marker2);
        window.external.MarkerRightClick(strclickInfo);
    });
    m.addEventListener("dblclick", function () {
        //console.log(strclickInfo);
        window.external.MarkerDoubleClick(strclickInfo);
    });
    mgr.addMarker(m, strTitle, strIconFilePath);
    mgr.showMarkers();
}


function setMapMarkerList(msg){
    var data = eval(msg);
    for (var i = 0; i < data.length; i++) {
        DisplayMarker1(data[i].MarkerPoint.dblLon,data[i].MarkerPoint.dblLat,data[i].MarkerDisplayTag,data[i].MarkerIconFilePath,data[i].CallbackValue);
    }
}

function clearMapMarkerList() {
    mgr.clearMarkers();
}

function removeMapSelectInfoMarker() {
    map.removeOverlay(marker2);
}


var circleLocationArea;
function DispalayLocationArea(dlbLon, dblLat, intAreaSize, intRegionType) {
    map.removeOverlay(circleLocationArea);
    var pointAreaCenter = new BMap.Point(dlbLon, dblLat);
    circleLocationArea = new BMap.Circle(pointAreaCenter, intAreaSize, { strokeColor: "red", strokeWeight: 0.1, strokeOpacity: 0.1 });
    circleLocationArea.setFillColor("red");
    circleLocationArea.setFillOpacity(0.3);    //多边形内透明度
    map.addOverlay(circleLocationArea);
}


function tesss(id) {
    mgr.resetAnimation();
    var vv = mgr.getMarker(id);
    vv.setAnimation(BMAP_ANIMATION_BOUNCE);
}
function test()
{
var vv="[{\"CallbackValue\":\"0001\",\"MarkerName\":\"设备1\",\"MarkerDisplayValue\":\"2019-06-24 22:32:50\",\"MarkerDisplayTag\":\"设备1\",\"MarkerIconFilePath\":\"G:\\\\Working\\\\Maintenance\\\\MapControl\\\\MapControl\\\\MapControlUse\\\\bin\\\\Debug\\\\MapFile\\\\MarkerFile\\\\MapIcon_PositionLabel1_Red.png\",\"MarkerIconWidth\":16,\"MarkerIconHeight\":16,\"MarkerFirstDisplayMapLevel\":0,\"MarkerPoint\":{\"dblLon\":118.67437582093041,\"dblLat\":24.873642139168862,\"intMapLevel\":0,\"cordinateSyatem\":2},\"MarkerID\":0},{\"CallbackValue\":\"0002\",\"MarkerName\":\"设备2\",\"MarkerDisplayValue\":\"2019-06-24 22:32:50\",\"MarkerDisplayTag\":\"设备2\",\"MarkerIconFilePath\":\"G:\\\\Working\\\\Maintenance\\\\MapControl\\\\MapControl\\\\MapControlUse\\\\bin\\\\Debug\\\\MapFile\\\\MarkerFile\\\\MapIcon_PositionLabel1_Red.png\",\"MarkerIconWidth\":16,\"MarkerIconHeight\":16,\"MarkerFirstDisplayMapLevel\":0,\"MarkerPoint\":{\"dblLon\":118.97047220667908,\"dblLat\":24.88768833395353,\"intMapLevel\":0,\"cordinateSyatem\":2},\"MarkerID\":0},{\"CallbackValue\":\"0003\",\"MarkerName\":\"设备3\",\"MarkerDisplayValue\":\"2019-06-24 22:32:50\",\"MarkerDisplayTag\":\"设备3\",\"MarkerIconFilePath\":\"G:\\\\Working\\\\Maintenance\\\\MapControl\\\\MapControl\\\\MapControlUse\\\\bin\\\\Debug\\\\MapFile\\\\MarkerFile\\\\MapIcon_PositionLabel1_Red.png\",\"MarkerIconWidth\":16,\"MarkerIconHeight\":16,\"MarkerFirstDisplayMapLevel\":0,\"MarkerPoint\":{\"dblLon\":118.60080778340027,\"dblLat\":24.797844466208936,\"intMapLevel\":0,\"cordinateSyatem\":2},\"MarkerID\":0},{\"CallbackValue\":\"0004\",\"MarkerName\":\"设备4\",\"MarkerDisplayValue\":\"2019-06-24 22:32:50\",\"MarkerDisplayTag\":\"设备4\",\"MarkerIconFilePath\":\"G:\\\\Working\\\\Maintenance\\\\MapControl\\\\MapControl\\\\MapControlUse\\\\bin\\\\Debug\\\\MapFile\\\\MarkerFile\\\\MapIcon_PositionLabel1_Red.png\",\"MarkerIconWidth\":16,\"MarkerIconHeight\":16,\"MarkerFirstDisplayMapLevel\":0,\"MarkerPoint\":{\"dblLon\":118.5117101092213,\"dblLat\":24.9012059963273,\"intMapLevel\":0,\"cordinateSyatem\":2},\"MarkerID\":0},{\"CallbackValue\":\"0005\",\"MarkerName\":\"设备5\",\"MarkerDisplayValue\":\"\",\"MarkerDisplayTag\":\"设备5\",\"MarkerIconFilePath\":\"G:\\\\Working\\\\Maintenance\\\\MapControl\\\\MapControl\\\\MapControlUse\\\\bin\\\\Debug\\\\MapFile\\\\MarkerFile\\\\MapIcon_PositionLabel1_Red.png\",\"MarkerIconWidth\":16,\"MarkerIconHeight\":16,\"MarkerFirstDisplayMapLevel\":0,\"MarkerPoint\":{\"dblLon\":118.60713037350143,\"dblLat\":24.868152187588024,\"intMapLevel\":0,\"cordinateSyatem\":2},\"MarkerID\":0}]";
    setMapMarkerList(vv);
}