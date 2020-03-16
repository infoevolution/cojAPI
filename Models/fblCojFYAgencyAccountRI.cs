using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cojApi.Models
{
    public class fblCojFYAgencyAccountRI
    {

    public int fy {get;set;}
    [Key, ColumnAttribute (Order = 0)]
    public long idRef {get;set;}
	public long acctSort {get;set;}
	public string code {get;set;}
	public string name {get;set;}
	public long agencyGroup {get;set;}
	public long agencyType {get;set;}
	public string gfGLDebit {get;set;}
	public string fundCenterCodeDebit {get;set;}
	public string gfFundBudgetDebit {get;set;}
	public string gfBudgetCodeDebit {get;set;}
	public string activityCodeDebit {get;set;}
	public string gfAccountCOJFeeDebit {get;set;}
	public string gfAccountCOJFineDebit {get;set;}
	public string gfAccountOwnerCodeDebit {get;set;}
	public string gfGLCredit {get;set;}
	public string fundCenterCodeCredit {get;set;}
	public string gfFundBudgetCredit {get;set;}
	public string gfBudgetCodeCredit {get;set;}
	public string activityCodeCredit {get;set;}
	public string gfAccountCOJFeeCredit {get;set;}
	public string gfAccountCOJFineCredit {get;set;}
	public string gfAccountOwnerCodeCredit {get;set;}

    }


}