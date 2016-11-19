using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Options;
using System.Web;
using DotNet.Highcharts.Helpers;
using System.Drawing;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;

namespace NFine.Application.ReportManage
{
    public class ReportDemoApp
    {
        private ITest_Report2Repository service = new Test_Report2Repository();
        public Highcharts GetCurveHightChartOption()
        {
            #region 构造HightChart数据集
            var dataList = service.IQueryable().ToList();
            var modelArr = dataList.GroupBy(t => t.F_Modle).Select(g => new { Model_Name = g.Key }).ToArray();
            var seriesArr = new Series[modelArr.Length];
            string[] categories = { "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" };
            for (int i = 0; i < modelArr.Length; i++)
            {
                var modelName = modelArr[i].Model_Name;
                var list = dataList.Where(t => t.F_Modle == modelName).OrderBy(t => t.F_Month).ToList();
                var arr = new object[list.Count];
                int index = 0;
                list.ForEach(t =>
                {
                    arr[index] = t.F_Fee;
                    index++;
                });
                seriesArr[i] = new Series { Name = modelName, Data = new DotNet.Highcharts.Helpers.Data(arr)};
            }
            #endregion

            #region 构造HightChart结构



            Highcharts chart = new Highcharts("chart")
                    .InitChart(new Chart
                    {
                        DefaultSeriesType = ChartTypes.Spline,
                        Type = ChartTypes.Spline
                    })
                    .SetTitle(new Title
                    {
                        Text = "太原美特好超市收入统计",
                        X = -20
                    })
                    .SetSubtitle(new Subtitle
                    {
                        Text = "来源：旗舰店官方数据",
                        X = -20
                    })
                    .SetXAxis(new XAxis { Categories = categories }) //ChartsData.Categories })
                    .SetYAxis(new YAxis
                    {
                        Title = new YAxisTitle { Text = "收入 （元）" },
                    })
                    .SetTooltip(new Tooltip
                    {
                        Crosshairs = new Crosshairs(true),
                        Shared = true
                    })
                    .SetPlotOptions(new PlotOptions
                    {
                        Spline =
                            new PlotOptionsSpline { LineWidth = 1, Marker = new PlotOptionsSplineMarker { Radius = 4, LineColor = ColorTranslator.FromHtml("#666666") } }
                    })
                    .SetSeries(seriesArr);
            #endregion

            return chart;
        }
    }
}
