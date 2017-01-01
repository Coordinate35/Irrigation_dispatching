using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irrigation_dispatching.Library
{
    public class Hydro
    {
        private List<Dictionary<string, int>> deptCropArea;
        private List<int> dryEarth;
        private List<Dictionary<string, int>> irrigationInstitution;
        private List<Dictionary<string, int>> roundOrderInfo;
        private List<Dictionary<string, double>> inflow;

        private Dictionary<int, int> cropArea;
        private List<int> roundOrderArea;
        private List<int> originalIrrigationRequirement;
        private List<double> grossIrrigationRequirement;
        private List<int> roundIrrigationDayNumber;
        private List<double> averageWaterSupplyOfCanalHead;
        private List<double> waterRequirement;
        private List<double> averageFlow;
        private List<double> inflowAveragePrediction;
        private List<double> utilizableCapacity;

        private double grossIrrigationConst;
        private double averageWaterSupplyOfCanalHeadConst;
        private double waterRequirementConst;
        private double basicUtilizableCapacity;
        private double averageFlowConst;
        private int daySeconds = 86400;
        private int roundDays = 10;
        private int roundPerMonth = 3;
        private int maxMonthDayNumber = 31;
        private int idealMaxDayNumber = 30;

        public Hydro(double grossIrrigationConst, double averageWaterSupplyOfCanalHeadConst, double waterRequirementConst, double basicUtilizableCapacity)
        {
            this.grossIrrigationConst = grossIrrigationConst;
            this.averageWaterSupplyOfCanalHeadConst = averageWaterSupplyOfCanalHeadConst;
            this.waterRequirementConst = waterRequirementConst;
            this.basicUtilizableCapacity = basicUtilizableCapacity;
            averageFlowConst = averageWaterSupplyOfCanalHeadConst;
        }

        public List<int> RoundOrderArea
        {
            get
            {
                return roundOrderArea;
            }
        }

        public List<int> OriginalIrrigationRequirement
        {
            get
            {
                return originalIrrigationRequirement;
            }
        }

        public List<double> GrossIrrigationRequirement
        {
            get
            {
                return grossIrrigationRequirement;
            }
        }

        public List<int> RoundIrrigationDayNumber
        {
            get
            {
                return RoundIrrigationDayNumber;
            }
        }

        public List<double> AverageWaterSupplyOfCanalHead
        {
            get
            {
                return averageWaterSupplyOfCanalHead;
            }
        }

        public List<double> WaterRequirement
        {
            get
            {
                return waterRequirement;
            }
        }

        public List<double> AverageFlow
        {
            get
            {
                return averageFlow;
            }
        }

        public List<double> InflowAveragePrediction
        {
            get
            {
                return inflowAveragePrediction;
            }
        }

        public List<double> UtilizableCapacity
        {
            get
            {
                return utilizableCapacity;
            }
        }

        public List<Dictionary<string, double>> Inflow
        {
            set
            {
                inflow = value;
            }
        }

        public List<Dictionary<string, int>> DeptCropArea
        {
            set
            {
                deptCropArea = value;
                CalculateCropArea();
            }
        }

        public List<Dictionary<string, int>> IrrigationInstitution
        {
            set
            {
                irrigationInstitution = value;
            }
        }

        public List<int> DryEarth
        {
            set
            {
                dryEarth = value;
            }
        }

        public List<Dictionary<string, int>> RoundOrderInfo
        {
            set
            {
                roundOrderInfo = value;
                CalculateRoundIrrigationDayNumber();
            }
        }

        private void CalculateRoundIrrigationDayNumber()
        {
            List<int> tempRoundIrrigationDayNumber = new List<int>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempRoundIrrigationDayNumber.Insert(i, (roundOrderInfo[i]["end_time"] - roundOrderInfo[i]["start_time"]) / daySeconds);
            }
            roundIrrigationDayNumber = tempRoundIrrigationDayNumber;
        }

        private void CalculateCropArea()
        {
            Dictionary<int, int> tempCropArea = new Dictionary<int, int>();
            foreach (Dictionary<string, int> item in deptCropArea)
            {
                if ( ! tempCropArea.ContainsKey(item["crop_id"]))
                {
                    tempCropArea.Add(item["crop_id"], item["area"]);
                }
                else
                {
                    tempCropArea[item["crop_id"]] += item["area"];
                }
            }
            cropArea = tempCropArea;
        }

        public void CalculateRoundOrderArea()
        {
            List<int> tempRoundOrderArea = new List<int>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempRoundOrderArea.Insert(i, 0);
            }
            foreach (Dictionary<string, int> rule in irrigationInstitution)
            {
                tempRoundOrderArea[rule["round_order"] - 1] += cropArea[rule["crop_id"]];
            }
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempRoundOrderArea[i] += dryEarth[i];
            }
            roundOrderArea = tempRoundOrderArea;
        }

        public void CalculateOriginalIrrigationRequirement()
        {
            List<int> tempOriginalIrrigationRequirement = new List<int>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempOriginalIrrigationRequirement.Insert(i, roundOrderArea[i] * roundOrderInfo[i]["qouta"]);
            }
            originalIrrigationRequirement = tempOriginalIrrigationRequirement;
        }

        public void CalculateGrossIrrigationRequirement()
        {
            List<double> tempGrossIrrigationRequirement = new List<double>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempGrossIrrigationRequirement.Insert(i, originalIrrigationRequirement[i] / grossIrrigationConst);
            }
            grossIrrigationRequirement = tempGrossIrrigationRequirement;
        }

        public void CalculateAverageWaterSupplyOfCanalHead()
        {
            List<double> tempAverageWaterSupplyOfCanalHead = new List<double>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempAverageWaterSupplyOfCanalHead.Insert(i, grossIrrigationRequirement[i] / roundIrrigationDayNumber[i] / averageWaterSupplyOfCanalHeadConst);
            }
            averageWaterSupplyOfCanalHead = tempAverageWaterSupplyOfCanalHead;
        }

        public void CalculateWaterRequirement()
        {
            List<double> tempWaterRequirement = new List<double>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempWaterRequirement.Insert(i, grossIrrigationRequirement[i] / waterRequirementConst);
            }
            waterRequirement = tempWaterRequirement;
        }

        public void CalculateAverageFlow()
        {
            List<double> tempAverageFlow = new List<double>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempAverageFlow.Insert(i, averageWaterSupplyOfCanalHead[i] / roundIrrigationDayNumber[i] / averageFlowConst);
            }
            averageFlow = tempAverageFlow;
        }

        public void CalculateInflowAveragePrediction()
        {
            List<double> tempInflowAveragePrediction = new List<double>();
            int lastEndRound = -1;
            int lastEndDay = roundDays;
            Dictionary<string, int> time = null;
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {              
                time = getDate(roundOrderInfo[i]["end_time"]);
                if (maxMonthDayNumber == time["day"])
                {
                    time["day"] = idealMaxDayNumber;
                }
                int endRound = (time["month"] - 1) * roundPerMonth + (0 == time["day"] % roundDays ? time["day"] / roundDays - 1 : time["day"] / roundDays) + 1 - 1;
                int endDay = (0 == time["day"] % roundDays) ? roundDays : time["day"] % roundDays;
                int startRound = (roundDays == lastEndDay ? lastEndRound + 1 : lastEndRound);
                int startDay = (roundDays == lastEndDay ? 1 : lastEndDay + 1);
                lastEndRound = endRound;
                lastEndDay = endDay;
                tempInflowAveragePrediction.Insert(i, 0);
                tempInflowAveragePrediction[i] += (1 - Convert.ToDouble(startDay - 1) / Convert.ToDouble(roundDays)) * inflow[startRound]["average_flow"];
                tempInflowAveragePrediction[i] += Convert.ToDouble(endDay) / Convert.ToDouble(roundDays) * inflow[endRound]["average_flow"];
                for (int j = startRound + 1; j < endRound; j++)
                {
                    tempInflowAveragePrediction[i] += inflow[j]["average_flow"];
                }
                tempInflowAveragePrediction[i] = tempInflowAveragePrediction[i] * averageFlowConst * roundDays;
            }
            inflowAveragePrediction = tempInflowAveragePrediction;
        }

        private Dictionary<string, int> getDate(int timeStamp)
        {
            Int64 eightHoursSecond = 28800;
            DateTime baseStamp = new DateTime(1970, 1, 1);
            Int64 totalTicks = (Convert.ToInt64(timeStamp) + eightHoursSecond) * 10000000 + baseStamp.Ticks;
            DateTime targetTime = new DateTime(totalTicks);

            Dictionary<string, int> result = new Dictionary<string, int>()
            {
                { "month", targetTime.Month },
                { "day", targetTime.Day }
            };
            return result;
        }

        public void CalculateUtilizableCapacity()
        {
            List<double> tempUtilizableCapacity = new List<double>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                double restWater = (0 == i ? basicUtilizableCapacity : tempUtilizableCapacity[i - 1]);
                tempUtilizableCapacity.Insert(i, restWater + inflowAveragePrediction[i] - waterRequirement[i]);
            }
            utilizableCapacity = tempUtilizableCapacity;
        }

        public List<Dictionary<string, object>> Result
        {
            get
            {
                List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                for (int i = 0; i < roundOrderInfo.Count; i++)
                {
                    Dictionary<string, Object> item = new Dictionary<string, object>()
                    {
                        { "round_order", i },
                        { "original_irrigation_requirement", originalIrrigationRequirement[i] },
                        { "gross_irrigation_requirement", grossIrrigationRequirement[i] },
                        { "average_water_supply_of_canal head", averageWaterSupplyOfCanalHead[i] },
                        { "avarage_flow", averageFlow[i] },
                        { "inflow_average_prediction", inflowAveragePrediction[i] },
                        { "utilizable_capacity", utilizableCapacity[i] }
                    };
                    result.Insert(i, item);
                }
                return result;
            }
        }
    }
}
