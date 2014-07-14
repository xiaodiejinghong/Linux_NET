/// <reference path="jquery-1.6.4.js" />
/// <reference path="jquery.signalR-2.1.0.js" />
(function ($,sign) {
    $(function () {
        var conn = $.connection("/realtime/trackingConn"),
            body = $("body"),
                        getRandomColor = function () {
                            return {
                                r: Math.round(Math.random() * 256),
                                g: Math.round(Math.random() * 256),
                                b: Math.round(Math.random() * 256)
                            };
                        },
            getInverseRgb = function (rgb) {
                return "rgb(" + (255 - rgb.r) + "," + (255 - rgb.g) + "," + (255 - rgb.b) + ")";
            },
            getRgb = function (rgb) {
                return "rgb(" + rgb.r + "," + rgb.b + "," + rgb.b + ")";
            },
            createElementIfNotExists = function (id) {
                var element = $("#" + id);
                if (element.length == 0) {
                    element = $("<span class='client' id=" + id + "></span>");
                    var color = getRandomColor();
                    element.css({ backgroundColor: getRgb(color), color: getInverseRgb(color) });
                    body.append(element).show();
                }
                return element;
            },
            startTracking = function () {
                body.mousemove(function (e) {
                    var data = { x: e.pageX, y: e.pageY, id: conn.id };
                    conn.send(data);
                });
            },
            receiveMsg = function (data) {
                data = JSON.parse(data);
                var domElementId = "id" + data.id,
                    elem = createElementIfNotExists(sign);
                $(elem).css({ left: data.x, top: data.y }).text(data.id);
            };
        conn.start(startTracking);
        conn.received(receiveMsg);
    });
}(jQuery,"xiaodiejinghong"));