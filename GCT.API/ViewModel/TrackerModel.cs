using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCT.API.ViewModel
{
    public class TrackerModel
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Region { get; set; }
        public int CountryId { get; set; }

        public string CountryName  {get; set; }

        public string ResponsibilityCentreNumber { get; set; }
        public string ResponsibilityCentreName { get; set; }
        public string ExpenseCategory { get; set; }
        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string RequisitionNumber { get; set; }
        public string CurrencyCode { get; set; }
        public decimal LocalCcyFxRate { get; set; }
        public decimal LocalCcyRPIRate { get; set; }
        public string BudgetLocalCcy { get; set; }
        public string BudgetUSCcy { get; set; }
        public string ActualLocalCcy { get; set; }
        public string ActualUSCcy { get; set; }
        public Nullable<System.DateTime> CashStartDate { get; set; }
        public Nullable<System.DateTime> CashEndDate { get; set; }
        public Nullable<System.DateTime> PLStartDate { get; set; }
        public Nullable<System.DateTime> PLEndDate { get; set; }
        public string RequisitionDescription { get; set; }
        public Nullable<int> PrimaryVarianceId { get; set; }
        public string PrimaryVariancName { get; set; }
        public Nullable<int> SecondaryVarianceId { get; set; }
        public string SecondaryVarianceName { get; set; }
        public string ReceiptNumber { get; set; }
        public string Comments { get; set; }
        public string Renewal { get; set; }
        public Nullable<decimal> TotalBudget { get; set; }
        public Nullable<decimal> VarianceInBudget { get; set; }
        public Nullable<decimal> NextYrLocalCcyBudget { get; set; }
        public Nullable<decimal> NextYrUSCcyBudget { get; set; }
        public string InternalContractor { get; set; }
        public string ITDirector { get; set; }
        public string AdditionalComments { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
       
        public Nullable<decimal> USD { get; set; }
        public Nullable<decimal> VAT { get; set; }
        public Nullable<decimal> Inflation1 { get; set; }
        public Nullable<decimal> Inflation2 { get; set; }
        public string January { get; set; }
        public string February { get; set; }
        public string March { get; set; }
        public string April { get; set; }
        public string May { get; set; }
        public string June { get; set; }
        public string July { get; set; }
        public string August { get; set; }
        public string Septemeber { get; set; }
        public string October { get; set; }
        public string November { get; set; }
        public string December { get; set; }      

    }
}