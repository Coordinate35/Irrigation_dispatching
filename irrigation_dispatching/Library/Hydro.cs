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
        private List<Dictionary<string, int>> inflow;

        private Dictionary<int, int> cropArea;
        private List<int> roundOrderArea;
        private List<int> originalIrrigationRequirement;
        private List<float> grossIrrigationRequirement;
        private List<int> roundIrrigationDayNumber;
        private List<float> averageWaterSupplyOfCanalHead;
        private List<float> waterRequirement;
        private List<float> averageFlow;
        private List<float> inflowAveragePrediction;
        private List<float> utilizableCapacity;

        private int grossIrrigationConst;
        private int averageWaterSupplyOfCanalHeadConst;
        private int waterRequirementConst;
        private int basicUtilizableCapacity;
        private int averageFlowConst;
        private int daySeconds = 86400;
        private int roundDays = 10;
        private int roundPerMonth = 3;
        private int inflowExpandTimes = 100;

        private void CalculateCropArea(int grossIrrigationConst, int averageWaterSupplyOfCanalHeadConst, int waterRequirementConst, int basicUtilizableCapacity)
        {
            this.grossIrrigationConst = grossIrrigationConst;
            this.averageWaterSupplyOfCanalHeadConst = averageWaterSupplyOfCanalHeadConst;
            this.waterRequirementConst = waterRequirementConst;
            this.basicUtilizableCapacity = basicUtilizableCapacity;
            averageFlowConst = averageWaterSupplyOfCanalHeadConst;
        }

        public List<Dictionary<string, int>> Inflow
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
                tempRoundOrderArea[rule["round_order"]] += cropArea[rule["crop_id"]];
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
            List<float> tempGrossIrrigationRequirement = new List<float>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempGrossIrrigationRequirement.Insert(i, originalIrrigationRequirement[i] / grossIrrigationConst);
            }
            grossIrrigationRequirement = tempGrossIrrigationRequirement;
        }

        public void CalculateAverageWaterSupplyOfCanalHead()
        {
            List<float> tempAverageWaterSupplyOfCanalHead = new List<float>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempAverageWaterSupplyOfCanalHead.Insert(i, grossIrrigationRequirement[i] / roundIrrigationDayNumber[i] / averageWaterSupplyOfCanalHeadConst);
            }
            averageWaterSupplyOfCanalHead = tempAverageWaterSupplyOfCanalHead;
        }

        public void CalculateWaterRequirement()
        {
            List<float> tempWaterRequirement = new List<float>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempWaterRequirement.Insert(i, grossIrrigationRequirement[i] / waterRequirementConst);
            }
            waterRequirement = tempWaterRequirement;
        }

        public void CalculateAverageFlow()
        {
            List<float> tempAverageFlow = new List<float>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                tempAverageFlow.Insert(i, averageWaterSupplyOfCanalHead[i] / roundIrrigationDayNumber[i] / averageFlowConst);
            }
            averageFlow = tempAverageFlow;
        }

        public void CalculateInflowAveragePrediction()
        {
            List<float> tempInflowAveragePrediction = new List<float>();
            for (int i = 0; i < roundOrderInfo.Count; i++)
            {
                Dictionary<string, int> time = null;
                time = getDate(roundOrderInfo[i]["start_time"]);
                int startMonth = time["month"];
                int startDay = time["day"];
                time = getDate(roundOrderInfo[i]["end_time"]);
                int endMonth = time["month"];
                int endDay = time["day"];
                tempInflowAveragePrediction.Insert(i, (1 - (float)(startDay % roundDays) / (float)roundDays) * inflow[startMonth * roundPerMonth + startDay / roundDays + 1]["average_flow"] / inflowExpandTimes);
                tempInflowAveragePrediction[i] += (float)(endDay % roundDays) / (float)roundDays * inflow[endMonth * roundPerMonth + endDay / roundDays + 1]["average_flow"] / inflowExpandTimes;
                for (int j = startMonth * roundPerMonth + startDay / roundDays + 2; j <= endMonth * roundPerMonth + endDay / roundDays; j++)
                {
                    tempInflowAveragePrediction[i] += (float)inflow[j]["average_flow"] / inflowExpandTimes;
                }
                tempInflowAveragePrediction[i] = tempInflowAveragePrediction[i] * averageFlowConst * roundDays;
            }
            inflowAveragePrediction = tempInflowAveragePrediction;
        }

        private Dictionary<string, int> getDate(int timeStamp)
        {
            DateTime baseStamp = new DateTime(1970, 1, 1);
            Int64 totalTicks = timeStamp * 10000000 + baseStamp.Ticks;
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
            List<float> tempUtilizableCapacity = new List<float>();
            tempUtilizableCapacity.Insert(0, basicUtilizableCapacity);
            for (int i = 1; i < roundOrderInfo.Count; i++)
            {
                tempUtilizableCapacity.Insert(i, tempUtilizableCapacity[i - 1] + inflowAveragePrediction[i] - waterRequirement[i]);
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
