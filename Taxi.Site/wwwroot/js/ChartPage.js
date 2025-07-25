const chartList = document.querySelectorAll('.chartjs');
chartList.forEach(function (chartListItem) {
    chartListItem.height = chartListItem.dataset.height;
});

const barChart = document.getElementById('barChart');
if (barChart) {
    const barChartVar = new Chart(barChart, {
        type: 'bar',
        data: {
            labels: @Html.Raw(xLabels),
            datasets: [
                {
                    data: @Html.Raw(yValues),
                    backgroundColor: cyanColor,
                    borderColor: 'transparent',
                    maxBarThickness: 15,
                    borderRadius: {
                        topRight: 15,
                        topLeft: 15
                    }
                }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            animation: {
                duration: 500
            },
            plugins: {
                tooltip: {
                    rtl: isRtl,
                    backgroundColor: cardColor,
                    titleColor: headingColor,
                    bodyColor: legendColor,
                    borderWidth: 1,
                    borderColor: borderColor
                },
                legend: {
                    display: false
                }
            },
            scales: {
                x: {
                    grid: {
                        color: borderColor,
                        drawBorder: false,
                        borderColor: borderColor
                    },
                    ticks: {
                        color: labelColor
                    }
                },
                y: {
                    min: 0,
                    max: 400,
                    grid: {
                        color: borderColor,
                        drawBorder: false,
                        borderColor: borderColor
                    },
                    ticks: {
                        stepSize: 100,
                        color: labelColor
                    }
                }
            }
        }
    });
}