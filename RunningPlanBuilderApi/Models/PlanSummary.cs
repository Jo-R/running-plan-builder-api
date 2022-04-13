namespace RunnningPlanBuilderApi.Models
{
    public class PlanSummary
    {
        public int Id { get; set; }
        public string PlanName { get; set; }

        public string PlanDescription { get; set; }

        public int UserId { get; set; }
    }
}
