//Flot Pie Chart
$(function () {

    var data = [{
        label: "Ludhiana",
        data: 1
    }, {
        label: "Jalandhar",
        data: 3
    }, {
        label: "Amritsar",
        data: 9
    }, {
        label: "Mohali",
        data: 20
    }];

    var plotObj = $.plot($("#flot-pie-chart"), data, {
        series: {
            pie: {
                show: true
            }
        },
        grid: {
            hoverable: true
        },
        tooltip: true,
        tooltipOpts: {
            content: "%p.0%, %s", // show percentages, rounding to 2 decimal places
            shifts: {
                x: 20,
                y: 0
            },
            defaultTheme: false
        }
    });

});