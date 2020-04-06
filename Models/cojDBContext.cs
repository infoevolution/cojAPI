using Microsoft.EntityFrameworkCore;

namespace cojApi.Models {
    public class cojDBContext : DbContext {
        public cojDBContext (DbContextOptions<cojDBContext> options) : base (options) { }

        //User
        public DbSet<cojUser> cojUsers { get; set; }
        public DbSet<cojGroup> cojGroups { get; set; }
        public DbSet<cojGroupMember> cojGroupMembers { get; set; }
        public DbSet<cojGroupRole> cojGroupRoles { get; set; }
        public DbSet<cojUserRole> cojUserRoles { get; set; }

        public DbSet<cojRole> cojRoles { get; set; }
        public DbSet<cojAgency> cojAgencys { get; set; }
        public DbSet<cojMasterData> cojMasterDatas { get; set; }
        public DbSet<cojDataCategory> cojDataCategorys { get; set; }
        public DbSet<cojBprFunction> cojBprFunctions { get; set; }
        public DbSet<cojBprFunctionAuthor> cojBprFunctionAuthors { get; set; }
        public DbSet<cojBprUserAuthor> cojBprUserAuthors { get; set; }
        public DbSet<cojBprGroupAuthor> cojBprGroupAuthors { get; set; }
        public DbSet<cojAccountBook> cojAccountBooks { get; set; }
        public DbSet<cojAgencyBuilding> cojAgencyBuildings { get; set; }
        public DbSet<cojAgencyBuildingOption> cojAgencyBuildingOptions { get; set; }
        public DbSet<cojAgencyBuildingHouse> cojAgencyBuildingHouses { get; set; }
        public DbSet<cojAgencyBuildingCondo> cojAgencyBuildingCondos { get; set; }
        public DbSet<cojAgencyManpower> cojAgencyManpowers { get; set; }
        public DbSet<cojAgencyLogin> cojAgencyLogins { get; set; }
        public DbSet<cojFYvalue> cojFYvalues { get; set; }
        public DbSet<cojFormControl> cojFormControls { get; set; }

        //COJBIS        
        public DbSet<cojPeriod> cojPeriods { get; set; }
        public DbSet<cojWork> cojWorks { get; set; }
        public DbSet<cojWorkActivity> cojWorkActivities { get; set; }
        public DbSet<cojWorkSubActivity> cojWorkSubActivities { get; set; }
        public DbSet<cojWorkBudgetType> cojWorkBudgetTypes { get; set; }
        public DbSet<cojWorkBudgetObj> cojWorkBudgetObjs { get; set; }
        public DbSet<cojWorkBudgetItem> cojWorkBudgetItems { get; set; }
        public DbSet<cojProject> cojProjects { get; set; }
        public DbSet<cojBISLink> cojBISLinks { get; set; }
        public DbSet<cojBISLinkWork> cojBISLinkWorks { get; set; }

        public DbSet<cojBISWork> cojBISWorks { get; set; }
        public DbSet<cojBISWorkActivity> cojBISWorkActivities { get; set; }
        public DbSet<cojBISWorkSubActivity> cojBISWorkSubActivities { get; set; }
        public DbSet<cojBISWorkBudgetType> cojBISWorkBudgetTypes { get; set; }
        public DbSet<cojBISWorkBudgetObj> cojBISWorkBudgetObjs { get; set; }
        public DbSet<cojBISWorkBudgetItem> cojBISWorkBudgetItems { get; set; }
        //COJStg
        public DbSet<cojStg> cojStgs { get; set; }
        public DbSet<cojStgPlan> cojStgPlans { get; set; }
        public DbSet<cojStgPlanStg> cojStgPlanStgs { get; set; }
        public DbSet<cojStgIndicatorGroup> cojStgIndicatorGroups { get; set; }
        public DbSet<cojStgIndicator> cojStgIndicators { get; set; }
        public DbSet<cojStgMission> cojStgMissions { get; set; }
        public DbSet<cojStgOperation> cojStgOperations { get; set; }
        public DbSet<cojStgPlanStgLink> cojStgPlanStgLinks { get; set; }
        public DbSet<cojUAT> cojUATs { get; set; }

        //CojBGPlan
        public DbSet<cojBGPlan> cojBGPlans { get; set; }
        public DbSet<cojBGPlanSum> cojBGPlanSums { get; set; }
        public DbSet<cojBGPlanStg> cojBGPlanStgs { get; set; }
        public DbSet<cojBGPlanStgWorkplanType> cojBGPlanStgWorkplanTypes { get; set; }
        public DbSet<cojBGPlanStgIndicator> cojBGPlanStgIndicators { get; set; }
        public DbSet<cojBGPlanWorkplan> cojBGPlanWorkplans { get; set; }
        public DbSet<cojBGPlanWorkplanActivity> cojBGPlanWorkplanActivities { get; set; }
        public DbSet<cojBGPlanWorkplanActivityItem> cojBGPlanWorkplanActivityItems { get; set; }
        public DbSet<cojBGPlanStgGoals> cojBGPlanStgGoals { get; set; }
        public DbSet<cojBGPlanWorkplanAgency> cojBGPlanWorkplanAgencies { get; set; }
        public DbSet<cojBGPlanWorkplanActivitySub> cojBGPlanWorkplanActivitySubs { get; set; }
        public DbSet<cojBGPlanWorkActivityItemSub> cojBGPlanWorkActivityItemSubs { get; set; }
        public DbSet<cojBGPlanWorkplanActivityIndicator> cojBGPlanWorkplanActivityIndicators { get; set; }
        public DbSet<cojBGPlanWorkplanActivityOperation> cojBGPlanWorkplanActivityOperations { get; set; }
        public DbSet<cojBGPlanWorkplanActivityObjective> cojBGPlanWorkplanActivityObjectives { get; set; }
        public DbSet<cojBGPlanWorkplanActivityObjectiveIndicator> cojBGPlanWorkplanActivityObjectiveIndicators { get; set; }
        public DbSet<cojBGPlanWorkplanActivityGoal> cojBGPlanWorkplanActivityGoals { get; set; }
        public DbSet<cojBGPlanWorkplanActivityGoalIndicator> cojBGPlanWorkplanActivityGoalIndicators { get; set; }
        public DbSet<cojBGPlanManageRequest> cojBGPlanManageRequests { get; set; }
        public DbSet<cojBGPlanAllot> cojBGPlanAllots { get; set; }
        public DbSet<cojBGPlanAllotItem> cojBGPlanAllotItems { get; set; }

        public DbSet<cojBGPlanTransferAllot> cojBGPlanTransferAllots { get; set; }
        public DbSet<cojBGTransfer> cojBGTransfers { get; set; }
        public DbSet<cojBGTransferDoc> cojBGTransferDocs { get; set; }
        public DbSet<cojBGTransferDocItem> cojBGTransferDocItems { get; set; }

        //cojPolicy        
        public DbSet<cojPolicy> cojPolicies { get; set; }
        public DbSet<cojPolicyItem> cojPolicyItems { get; set; }

        //cojNationStg
        public DbSet<cojNationPlan> cojNationPlans { get; set; }
        public DbSet<cojNationPlanStg> cojNationPlanStgs { get; set; }
        public DbSet<cojNationPlanGoal> cojNationPlanGoals { get; set; }
        public DbSet<cojNationPlanGoalIndicator> cojNationPlanGoalIndicators { get; set; }
        public DbSet<cojNationPlanGuildline> cojNationPlanGuildlines { get; set; }
        public DbSet<cojNationPlanGuildlineItem> cojNationPlanGuildlineItems { get; set; }
        public DbSet<cojNationStg> cojNationStgs { get; set; }
        public DbSet<cojNationStgSector> cojNationStgSectors { get; set; }
        public DbSet<cojNationStgIssue> cojNationStgIssues { get; set; }
        public DbSet<cojNationStgIndicator> cojNationStgIndicators { get; set; }

        //cojData
        public DbSet<cojData> cojDatas { get; set; }

        //cojLog
        public DbSet<cojLog> cojLogs { get; set; }

        //cojRevenue
        public DbSet<cojRevenue> cojRevenues { get; set; }
        public DbSet<cojRevenueAllot> cojRevenueAllots { get; set; }
        public DbSet<cojReserve> cojReserves { get; set; }

        //cojIntegration
        public DbSet<cojIntegration> cojIntegrations { get; set; }
        public DbSet<cojIntegrationAllot> cojIntegrationAllots { get; set; }
        public DbSet<cojIntegrationAllotItem> cojIntegrationAllotItems { get; set; }

        //RegionReserve
        public DbSet<cojRegionReserveAllot> cojRegionReserveAllots { get; set; }
        public DbSet<cojRegionReserveActivityItem> cojRegionReserveActivityItems { get; set; }
        public DbSet<cojRegionReserveExtra> cojRegionReserveExtras { get; set; }
        public DbSet<cojRegionAllot> cojRegionAllots { get; set; }
        public DbSet<cojRegionAllotItem> cojRegionAllotItems { get; set; }

        //cojSys
        public DbSet<cojAppConfig> cojAppConfigs { get; set; }

        //sp
        public virtual DbSet<spCojLoginRole> spCojLoginRoles { get; set; }
        public virtual DbSet<spCojFY> spCojFYs { get; set; }
        public virtual DbSet<spCojFYWorkplanType> spCojFYWorkplanTypes { get; set; }
        public virtual DbSet<spCojFYWorkplan> spCojFYWorkplans { get; set; }
        public virtual DbSet<spCojFYWorkplanFund> spCojFYWorkplanFunds { get; set; }
        public virtual DbSet<spCojFYWorkplanActivity> spCojFYWorkplanActivitys { get; set; }
        public virtual DbSet<spCojFYWorkplanActivityFund> spCojFYWorkplanActivityFunds { get; set; }
        //** add: 26-01-2563
        public virtual DbSet<spCojFYWorkplanActivityBGType> spCojFYWorkplanActivityBGTypes { get; set; }
        public virtual DbSet<spCojFYTransferAllotWork> spCojFYTransferAllotWorks { get; set; }
        public virtual DbSet<spCojFYTransferAllotWorkAgencyType> spCojFYTransferAllotWorkAgencyTypes { get; set; }
        public virtual DbSet<spCojFYTransferAllotWorkAgency> spCojFYTransferAllotWorkAgencys { get; set; }
        public virtual DbSet<spCojFYTransferAllotWorkAgencyDetail> spCojFYTransferAllotWorkAgencyDetails { get; set; }

        //sp Transfer Request
        public virtual DbSet<spCojBGTransferRequestAgency> spCojBGTransferRequestAgencys { get; set; }
        public virtual DbSet<spCojBGTransferRequestAgencyType> spCojBGTransferRequestAgencyTypes { get; set; }
        public virtual DbSet<spCojBGTransferRequestAgencyDetail> spCojBGTransferRequestAgencyDetails { get; set; }
        public virtual DbSet<spCojBGTransferRequestAgencyDetailItem> spCojBGTransferRequestAgencyDetailItems { get; set; }

        //sp Transfer Allot
        public virtual DbSet<spRet> sp_cojBGPlanTransferAllotPost { get; set; }
        public virtual DbSet<spRet> sp_cojBGPlanQuarterPost { get; set; }
        public virtual DbSet<spRet> sp_cojBGPlanQuarterAllotPost { get; set; }

        //sp FY Transfer Request
        public virtual DbSet<spCojFYTransferRequest> spCojFYTransferRequests { get; set; }
        public virtual DbSet<spCojFYTransferApprove> spCojFYTransferApproves { get; set; }

        public virtual DbQuery<vwCojBGTransferRequest> vwCojBGTransferRequests { get; set; }
        public virtual DbQuery<vwCojBGTransferApprove> vwCojBGTransferApproves { get; set; }

        public virtual DbSet<spRet> spRet { get; set; }
        public virtual DbSet<spRet> sp_cojBGPlanAllotPost { get; set; }
        public virtual DbSet<spRet> sp_cojBGTransferRequestPost { get; set; }
        public virtual DbSet<spRet> sp_cojBGTransferRequestProposePost { get; set; }
        public virtual DbSet<spRet> sp_cojBGTransferRequestApprovePost { get; set; }

        public virtual DbSet<spRet> sp_cojBISWorkCarryOver { get; set; }

        //** add 27/1/2563       
        public virtual DbSet<spCojBGTransferRequestAgencyPropose> sp_cojBGTransferRequestAgencyPropose { get; set; }

        public virtual DbQuery<vwCojAllotRequestTransferFY> vwCojAllotRequestTransferFYs { get; set; }

        //** add 27/1/2563

        //** add 28/1/2563       
        public virtual DbSet<spCojBGTransferRequestAgencyProposeSumCOJ> sp_cojBGTransferRequestAgencyProposeSumCOJ { get; set; }

        public virtual DbSet<spCojBGTransferRequestAgencyProposeSumAgencyType> sp_cojBGTransferRequestAgencyProposeSumAgencyType { get; set; }

        public virtual DbSet<spCojBGTransferRequestAgencyProposeSumAgencyAccount> sp_cojBGTransferRequestAgencyProposeSumAgencyAccount { get; set; }

        //** add 28/1/2563

        //** add 9/2/2563
        public virtual DbSet<spCojBGTransferApproveGetDocument> sp_cojBGTransferApproveGetDocument { get; set; }
        //** add 9/2/2563

        public virtual DbQuery<vwCojBGTransferRequestAgency> vwCojBGTransferRequestAgencys { get; set; }

        public virtual DbQuery<vwCojBGTransferRequestAgencyItem> vwCojBGTransferRequestAgencyItems { get; set; }

        public virtual DbQuery<vwCojAllotRequestTransferBGPlan> vwCojAllotRequestTransferBGPlans { get; set; }

        public virtual DbQuery<vwCojAllotRequestTransferBGPlanWorkplanType> vwCojAllotRequestTransferBGPlanWorkplanTypes { get; set; }

        public virtual DbQuery<vwCojAllotRequestTransferBGPlanWorkplan> vwCojAllotRequestTransferBGPlanWorkplans { get; set; }

        public virtual DbQuery<vwCojAllotRequestTransferBGPlanWorkActivity> vwCojAllotRequestTransferBGPlanWorkActivitys { get; set; }

        public virtual DbQuery<vwCojAllotRequestTransferBGPlanWorkActivityBudgetType> vwCojAllotRequestTransferBGPlanWorkActivityBudgetTypes { get; set; }

        public virtual DbQuery<vwCojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllot> vwCojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllots { get; set; }
        public virtual DbQuery<vwCojAgencyAccountBook> vwCojAgencyAccountBooks { get; set; }

        //** Allot : อนุมัติเม็ดเงิน เงินสำรองภาค
        public virtual DbQuery<vwCojRegionReserveFYWorkActivityBudgetType> vwCojRegionReserveFYWorkActivityBudgetTypes { get; set; }

        public virtual DbQuery<vwCojRegionReserveFYWorkActivity> vwCojRegionReserveFYWorkActivitys { get; set; }
        public virtual DbQuery<vwCojRegionReserveFYWork> vwCojRegionReserveFYWorks { get; set; }
        public virtual DbQuery<vwCojRegionReserveFYAgency> vwCojRegionReserveFYAgencys { get; set; }

        //** Allot : อนุมัติเม็ดเงิน
        public virtual DbQuery<vwCojFYAllotWorkplan> vwCojFYAllotWorkplans { get; set; }
        public virtual DbQuery<vwCojFYAllotWorkplanActivity> vwCojFYAllotWorkplanActivitys { get; set; }
        public virtual DbQuery<vwCojFYAllotWorkplanActivityBudgetType> vwCojFYAllotWorkplanActivityBudgetTypes { get; set; }
        public virtual DbQuery<vwCojFYAllotWorkplanActivityBudgetTypeAllot> vwCojFYAllotWorkplanActivityBudgetTypeAllots { get; set; }

        //ftbl : function table
        public virtual DbSet<cojBGPlanWork> ftblCojBGPlanWork { get; set; }
        public virtual DbSet<cojBGPlanWorkActivity> ftblCojBGPlanWorkActivity { get; set; }
        public virtual DbSet<cojBGPlanWorkActivityBGType> ftblCojBGPlanWorkActivityBGType { get; set; }
        public virtual DbSet<cojBGPlanWorkActivityBGTypeFund> ftblCojBGPlanWorkActivityBGTypeFund { get; set; }
        public virtual DbSet<cojBGPlanWorkActivityFund> ftblCojBGPlanWorkActivityFund { get; set; }

        public virtual DbSet<fblCojFYWorkplanType> fblCojFYWorkplanType { get; set; }
        public virtual DbSet<fblCojFYWorkplan> fblCojFYWorkplan { get; set; }
        public virtual DbSet<fblCojFYWorkplanActivity> fblCojFYWorkplanActivity { get; set; }
        public virtual DbSet<fblCojFYWorkplanActivityBGType> fblCojFYWorkplanActivityBGType { get; set; }
        public virtual DbSet<fblCojFYWorkplanActivityBGTypeFund> fblCojFYWorkplanActivityBGTypeFund { get; set; }

        public virtual DbSet<fblCojFYWorkplanActivityBGTypeFundB> fblCojFYWorkplanActivityBGTypeFundB { get; set; }

        public virtual DbSet<fblCojFYWorkplanActivityItem> fblCojFYWorkplanActivityItem { get; set; }

        public virtual DbSet<fblCojFYWorkplanBGTypeFundB> fblCojFYWorkplanBGTypeFundB { get; set; }

        public virtual DbSet<fblCojFYCojStg> fblCojFYCojStg { get; set; }
        public virtual DbSet<fblCojFYCojStgWorkplanType> fblCojFYCojStgWorkplanType { get; set; }
        public virtual DbSet<fblCojFYCojStgWorkplan> fblCojFYCojStgWorkplan { get; set; }
        public virtual DbSet<fblCojFYCojStgWorkplanActivity> fblCojFYCojStgWorkplanActivity { get; set; }
        public virtual DbSet<fblCojFYCojStgWorkplanActivityBGType> fblCojFYCojStgWorkplanActivityBGType { get; set; }
        public virtual DbSet<fblCojFYCojStgWorkplanActivityBGTypeFund> fblCojFYCojStgWorkplanActivityBGTypeFund { get; set; }

        public virtual DbSet<fblCojFYAgencyAccountRI> fblCojFYAgencyAccountRI { get; set; }

        public virtual DbSet<fblCojBGPlanQuarter> fblCojBGPlanQuarter { get; set; }
        public virtual DbSet<fblCojBGPlanQuarterWorkplan> fblCojBGPlanQuarterWorkplan { get; set; }
        public virtual DbSet<fblCojBGPlanQuarterWorkplanActivity> fblCojBGPlanQuarterWorkplanActivity { get; set; }
        public virtual DbSet<fblCojBGPlanQuarterWorkplanActivityBudgetType> fblCojBGPlanQuarterWorkplanActivityBudgetType { get; set; }
        public virtual DbSet<cojReserveAllotSummary> cojReserveAllotSummary { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            //ftbl
            modelBuilder.Entity<cojBGPlanWork> ()
                .HasKey (a => new { a.fy, a.cojBGWorkplanId });

            modelBuilder.Entity<cojBGPlanWorkActivity> ()
                .HasKey (a => new { a.fy, a.cojBGWorkplanId, a.cojWorkActivityId });

            modelBuilder.Entity<cojBGPlanWorkActivityBGType> ()
                .HasKey (a => new { a.fy, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetType });

            modelBuilder.Entity<cojBGPlanWorkActivityBGTypeFund> ()
                .HasKey (a => new { a.fy, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetType, a.cojFund });

            modelBuilder.Entity<cojBGPlanWorkActivityFund> ()
                .HasKey (a => new { a.fy, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojFund });

            modelBuilder.Entity<fblCojFYWorkplanType> ()
                .HasKey (a => new { a.fy, a.cojWorkplanTypeId });
            modelBuilder.Entity<fblCojFYWorkplan> ()
                .HasKey (a => new { a.fy, a.cojWorkplanTypeId, a.cojBGWorkplanId });
            modelBuilder.Entity<fblCojFYWorkplanActivity> ()
                .HasKey (a => new { a.fy, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId });
            modelBuilder.Entity<fblCojFYWorkplanActivityBGType> ()
                .HasKey (a => new { a.fy, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetTypeId });
            modelBuilder.Entity<fblCojFYWorkplanActivityBGTypeFund> ()
                .HasKey (a => new { a.fy, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetTypeId, a.cojFund });

            modelBuilder.Entity<fblCojFYWorkplanActivityBGTypeFundB> ()
                .HasKey (a => new { a.fy, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetTypeId });

            modelBuilder.Entity<fblCojFYWorkplanBGTypeFundB> ()
                .HasKey (a => new { a.fy, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojBudgetTypeId });
            
            modelBuilder.Entity<fblCojFYWorkplanActivityItem> ()
                .HasKey (a => new { a.id});

            modelBuilder.Entity<fblCojFYCojStg> ()
                .HasKey (a => new { a.fy, a.cojStgId });
            modelBuilder.Entity<fblCojFYCojStgWorkplanType> ()
                .HasKey (a => new { a.fy, a.cojStgId, a.cojWorkplanTypeId });
            modelBuilder.Entity<fblCojFYCojStgWorkplan> ()
                .HasKey (a => new { a.fy, a.cojStgId, a.cojWorkplanTypeId, a.cojBGWorkplanId });
            modelBuilder.Entity<fblCojFYCojStgWorkplanActivity> ()
                .HasKey (a => new { a.fy, a.cojStgId, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId });
            modelBuilder.Entity<fblCojFYCojStgWorkplanActivityBGType> ()
                .HasKey (a => new { a.fy, a.cojStgId, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetTypeId });
            modelBuilder.Entity<fblCojFYCojStgWorkplanActivityBGTypeFund> ()
                .HasKey (a => new { a.fy, a.cojStgId, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetTypeId, a.cojFund });

            modelBuilder.Entity<fblCojFYAgencyAccountRI> ()
                .HasKey (a => new { a.idRef });

            modelBuilder.Entity<fblCojBGPlanQuarter> ()
                .HasKey (a => new { a.idRef, a.idRefPlan, a.isRegionReserve });

            modelBuilder.Entity<fblCojBGPlanQuarterWorkplan> ()
                .HasKey (a => new { a.fy, a.cojFund, a.cojWorkplanTypeId, a.cojBGWorkplanId });

            modelBuilder.Entity<fblCojBGPlanQuarterWorkplanActivity> ()
                .HasKey (a => new { a.fy, a.cojFund, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId });

            modelBuilder.Entity<fblCojBGPlanQuarterWorkplanActivityBudgetType> ()
                .HasKey (a => new { a.fy, a.cojFund, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetType });

            modelBuilder.Entity<cojReserveAllotSummary> ()
                .HasKey (a => new { a.fy, a.cojFund });

            //sp
            modelBuilder.Entity<spCojFYWorkplan> ()
                .HasKey (a => new { a.cojWorkplanTypeId, a.cojBGWorkplanId });

            modelBuilder.Entity<spCojFYWorkplanFund> ()
                .HasKey (a => new { a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojFund });

            modelBuilder.Entity<spCojFYWorkplanActivity> ()
                .HasKey (a => new { a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId });

            modelBuilder.Entity<spCojFYWorkplanActivityFund> ()
                .HasKey (a => new { a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojFund });

            //add : 26-01-2563
            modelBuilder.Entity<spCojFYWorkplanActivityBGType> ()
                .HasKey (a => new { a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId, a.cojBudgetType });

            modelBuilder.Entity<spCojBGTransferRequestAgencyDetail> ()
                .HasKey (a => new { a.itemNo, a.cojAgencyId });

            //add : 27-01-2563 -> start
            modelBuilder.Entity<spCojBGTransferRequestAgencyPropose> ()
                .HasKey (a => new { a.allotFy, a.cojBGPlanAllotToAgency });

            //modelBuilder.Entity<vwCojAllotRequestTransferBGPlanWorkActivity> ()
            //    .HasKey (a => new { a.cojBGPlanId, a.cojWorkplanTypeId, a.cojBGWorkplanId, a.cojWorkActivityId });

            //add : 27-01-2563 --> end

            //add : 28-01-2563 --> start
            modelBuilder.Entity<spCojBGTransferRequestAgencyProposeSumCOJ> ()
                .HasKey (a => new { a.allotFy, a.cojFund });

            modelBuilder.Entity<spCojBGTransferRequestAgencyProposeSumAgencyType> ()
                .HasKey (a => new { a.allotFy, a.agencyType });

            modelBuilder.Entity<spCojBGTransferRequestAgencyProposeSumAgencyAccount> ()
                .HasKey (a => new { a.itemNo, a.cojAgencyAccountId });
            //add : 28-01-2563 --> end

            //add : 09-02-2563 --> start
            modelBuilder.Entity<spCojBGTransferApproveGetDocument> ()
                .HasKey (a => new { a.itemNo, a.cojAgencyAccountId });
            //add : 09-02-2563 --> end

            //อนุมัติเม็ดเงิน : เงินสำรองภาค

            modelBuilder.Query<vwCojRegionReserveFYAgency> ().ToView ("vw_cojRegionReserveFYAgency");
            modelBuilder.Query<vwCojRegionReserveFYWork> ().ToView ("vw_cojRegionReserveFYWork");
            modelBuilder.Query<vwCojRegionReserveFYWorkActivity> ().ToView ("vw_cojRegionReserveFYWorkActivity");
            modelBuilder.Query<vwCojRegionReserveFYWorkActivityBudgetType> ().ToView ("vw_cojRegionReserveFYWorkActivityBudgetType");

            //อนุมัติเม็ดเงิน : งาน/กิจกรรม/งบรายจ่าย/รายการอนุมัติเม็ดเงิน

            modelBuilder.Query<vwCojFYAllotWorkplan> ().ToView ("vw_cojFYAllotWorkplan");
            modelBuilder.Query<vwCojFYAllotWorkplanActivity> ().ToView ("vw_cojFYAllotWorkplanActivity");
            modelBuilder.Query<vwCojFYAllotWorkplanActivityBudgetType> ().ToView ("vw_cojFYAllotWorkplanActivityBudgetType");
            modelBuilder.Query<vwCojFYAllotWorkplanActivityBudgetTypeAllot> ().ToView ("vw_cojFYAllotWorkplanActivityBudgetTypeAllot");

            modelBuilder.Query<vwCojBGTransferRequestAgency> ().ToView ("vw_cojBGTransferRequestAgencys");

            modelBuilder.Query<vwCojBGTransferRequestAgencyItem> ().ToView ("vw_cojBGTransferRequestAgencyItems");
            //-------
            modelBuilder.Query<vwCojBGTransferRequest> ().ToView ("vw_cojBGTransferRequest");
            modelBuilder.Query<vwCojBGTransferApprove> ().ToView ("vw_cojBGTransferApprove");

            modelBuilder.Query<vwCojAllotRequestTransferFY> ().ToView ("vw_cojAllotRequestTransferFY");

            modelBuilder.Query<vwCojAllotRequestTransferBGPlan> ().ToView ("vw_cojAllotRequestTransferBGPlan");

            modelBuilder.Query<vwCojAllotRequestTransferBGPlanWorkActivity> ().ToView ("vw_cojAllotRequestTransferBGPlanWorkActivity");

            modelBuilder.Query<vwCojAllotRequestTransferBGPlanWorkplanType> ().ToView ("vw_cojAllotRequestTransferBGPlanWorkplanType");

            modelBuilder.Query<vwCojAllotRequestTransferBGPlanWorkplan> ().ToView ("vw_cojAllotRequestTransferBGPlanWorkplan");

            modelBuilder.Query<vwCojAllotRequestTransferBGPlanWorkActivityBudgetType> ().ToView ("vw_cojAllotRequestTransferBGPlanWorkActivityBudgetType");

            modelBuilder.Query<vwCojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllot> ().ToView ("vw_cojRequestTransferAllotBGPlanWorkActivityBudgetTypeAllot");

            modelBuilder.Query<vwCojAgencyAccountBook> ().ToView ("vw_cojAgencyAccountBook");

            //Sys
            modelBuilder.Entity<cojAppConfig> (entity => {
                entity.ToTable ("tbl_cojAppConfig");
            });

            //User
            modelBuilder.Entity<cojUser> (entity => {
                entity.ToTable ("tbl_cojUser");
            });
            modelBuilder.Entity<cojGroup> (entity => {
                entity.ToTable ("tbl_cojGroup");
            });
            modelBuilder.Entity<cojGroupMember> (entity => {
                entity.ToTable ("tbl_cojGroupMember");
            });
            modelBuilder.Entity<cojGroupRole> (entity => {
                entity.ToTable ("tbl_cojGroupRole");
            });
            modelBuilder.Entity<cojUserRole> (entity => {
                entity.ToTable ("tbl_cojUserRole");
            });

            modelBuilder.Entity<cojRole> (entity => {
                entity.ToTable ("tbl_cojRole");
            });
            modelBuilder.Entity<cojAgency> (entity => {
                entity.ToTable ("tbl_cojAgency");
            });
            modelBuilder.Entity<cojDataCategory> (entity => {
                entity.ToTable ("tbl_cojDataCategory");
            });
            modelBuilder.Entity<cojData> (entity => {
                entity.ToTable ("tbl_cojData");
            });
            modelBuilder.Entity<cojMasterData> (entity => {
                entity.ToTable ("tbl_cojMasterData");
            });
            modelBuilder.Entity<cojBprFunction> (entity => {
                entity.ToTable ("tbl_cojBprFunction");
            });
            modelBuilder.Entity<cojBprFunctionAuthor> (entity => {
                entity.ToTable ("tbl_cojBprFunctionAuthor");
            });
            modelBuilder.Entity<cojBprGroupAuthor> (entity => {
                entity.ToTable ("tbl_cojBprGroupAuthor");
            });
            modelBuilder.Entity<cojBprUserAuthor> (entity => {
                entity.ToTable ("tbl_cojBprUserAuthor");
            });
            modelBuilder.Entity<cojAccountBook> (entity => {
                entity.ToTable ("tbl_cojAccountBook");
            });
            modelBuilder.Entity<cojAgencyBuilding> (entity => {
                entity.ToTable ("tbl_cojAgencyBuilding");
            });
            modelBuilder.Entity<cojAgencyBuildingOption> (entity => {
                entity.ToTable ("tbl_cojAgencyBuildingOption");
            });
            modelBuilder.Entity<cojAgencyBuildingHouse> (entity => {
                entity.ToTable ("tbl_cojAgencyBuildingHouse");
            });
            modelBuilder.Entity<cojAgencyBuildingCondo> (entity => {
                entity.ToTable ("tbl_cojAgencyBuildingCondo");
            });
            modelBuilder.Entity<cojAgencyManpower> (entity => {
                entity.ToTable ("tbl_cojAgencyManpower");
            });
            modelBuilder.Entity<cojAgencyLogin> (entity => {
                entity.ToTable ("tbl_cojAgencyLogin");
            });
            modelBuilder.Entity<cojFYvalue> (entity => {
                entity.ToTable ("tbl_cojFYvalue");
            });
            modelBuilder.Entity<cojFormControl> (entity => {
                entity.ToTable ("tbl_cojFormControl");
            });

            //COJ BIS
            modelBuilder.Entity<cojPeriod> (entity => {
                entity.ToTable ("tbl_cojPeriod");
            });
            modelBuilder.Entity<cojWork> (entity => {
                entity.ToTable ("tbl_cojWork");
            });
            modelBuilder.Entity<cojWorkActivity> (entity => {
                entity.ToTable ("tbl_cojWorkActivity");
            });
            modelBuilder.Entity<cojWorkSubActivity> (entity => {
                entity.ToTable ("tbl_cojWorkSubActivity");
            });
            modelBuilder.Entity<cojWorkBudgetType> (entity => {
                entity.ToTable ("tbl_cojWorkBudgetType");
            });
            modelBuilder.Entity<cojWorkBudgetObj> (entity => {
                entity.ToTable ("tbl_cojWorkBudgetObj");
            });
            modelBuilder.Entity<cojWorkBudgetItem> (entity => {
                entity.ToTable ("tbl_cojWorkBudgetItem");
            });
            modelBuilder.Entity<cojProject> (entity => {
                entity.ToTable ("tbl_cojProject");
            });
            modelBuilder.Entity<cojBISLink> (entity => {
                entity.ToTable ("tbl_cojBISLink");
            });
            modelBuilder.Entity<cojBISLinkWork> (entity => {
                entity.ToTable ("tbl_cojBISLinkWork");
            });
            modelBuilder.Entity<cojBISWork> (entity => {
                entity.ToTable ("tbl_cojBISWork");
            });
            modelBuilder.Entity<cojBISWorkActivity> (entity => {
                entity.ToTable ("tbl_cojBISWorkActivity");
            });
            modelBuilder.Entity<cojBISWorkSubActivity> (entity => {
                entity.ToTable ("tbl_cojBISWorkSubActivity");
            });
            modelBuilder.Entity<cojBISWorkBudgetType> (entity => {
                entity.ToTable ("tbl_cojBISWorkBudgetType");
            });
            modelBuilder.Entity<cojBISWorkBudgetObj> (entity => {
                entity.ToTable ("tbl_cojBISWorkBudgetObj");
            });
            modelBuilder.Entity<cojBISWorkBudgetItem> (entity => {
                entity.ToTable ("tbl_cojBISWorkBudgetItem");
            });

            //COJ STG
            modelBuilder.Entity<cojStg> (entity => {
                entity.ToTable ("tbl_cojStg");
            });
            modelBuilder.Entity<cojStgPlan> (entity => {
                entity.ToTable ("tbl_cojStgPlan");
            });
            modelBuilder.Entity<cojStgPlanStg> (entity => {
                entity.ToTable ("tbl_cojStgPlanStg");
            });
            modelBuilder.Entity<cojStgIndicatorGroup> (entity => {
                entity.ToTable ("tbl_cojStgIndicatorGroup");
            });
            modelBuilder.Entity<cojStgIndicator> (entity => {
                entity.ToTable ("tbl_cojStgIndicator");
            });
            modelBuilder.Entity<cojStgMission> (entity => {
                entity.ToTable ("tbl_cojStgMission");
            });
            modelBuilder.Entity<cojStgOperation> (entity => {
                entity.ToTable ("tbl_cojStgOperation");
            });
            modelBuilder.Entity<cojStgPlanStgLink> (entity => {
                entity.ToTable ("tbl_cojStgPlanStgLink");
            });
            modelBuilder.Entity<cojUAT> (entity => {
                entity.ToTable ("tbl_cojUAT");
            });

            //COJ BgPlan
            modelBuilder.Entity<cojBGPlan> (entity => {
                entity.ToTable ("tbl_cojBGPlan");
            });
            modelBuilder.Entity<cojBGPlanSum> (entity => {
                entity.ToTable ("tbl_cojBGPlanSum");
            });
            modelBuilder.Entity<cojBGPlanStg> (entity => {
                entity.ToTable ("tbl_cojBGPlanStg");
            });
            modelBuilder.Entity<cojBGPlanStgWorkplanType> (entity => {
                entity.ToTable ("tbl_cojBGPlanStgWorkplanType");
            });
            modelBuilder.Entity<cojBGPlanStgIndicator> (entity => {
                entity.ToTable ("tbl_cojBGPlanStgIndicator");
            });
            modelBuilder.Entity<cojBGPlanWorkplan> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplan");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivity> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivity");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivityItem> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivityItem");
            });
            modelBuilder.Entity<cojBGPlanStgGoals> (entity => {
                entity.ToTable ("tbl_cojBGPlanStgGoal");
            });
            modelBuilder.Entity<cojBGPlanWorkplanAgency> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanAgency");
            });
            modelBuilder.Entity<cojBGPlanWorkActivityItemSub> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkActivityItemSub");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivitySub> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivitySub");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivityIndicator> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivityIndicator");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivityOperation> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivityOperation");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivityObjective> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivityObjective");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivityObjectiveIndicator> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivityObjectiveIndicator");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivityGoal> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivityGoal");
            });
            modelBuilder.Entity<cojBGPlanWorkplanActivityGoalIndicator> (entity => {
                entity.ToTable ("tbl_cojBGPlanWorkplanActivityGoalIndicator");
            });
            modelBuilder.Entity<cojBGPlanManageRequest> (entity => {
                entity.ToTable ("tbl_cojBGPlanManageRequest");
            });

            modelBuilder.Entity<cojBGPlanAllot> (entity => {
                entity.ToTable ("tbl_cojBGPlanAllot");
            });
            //  modelBuilder.Entity<cojBGPlanAllot> ()
            //     .Property(a => a.idRef).ValueGeneratedOnAddOrUpdate();
            //  modelBuilder.Entity<cojBGPlanAllot> ()
            //     .Property(a => a.startDate).ValueGeneratedOnAddOrUpdate();
            //  modelBuilder.Entity<cojBGPlanAllot> ()
            //     .Property(a => a.endDate).ValueGeneratedOnAddOrUpdate();

            //  modelBuilder.Entity<cojBGPlanAllot>()
            //     .Property(b => b.idRef)
            //     .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<cojBGPlanAllotItem> (entity => {
                entity.ToTable ("tbl_cojBGPlanAllotItem");
            });

            //cojBGTransfer
            modelBuilder.Entity<cojBGTransfer> (entity => {
                entity.ToTable ("tbl_cojBGTransfer");
            });
            modelBuilder.Entity<cojBGTransferDoc> (entity => {
                entity.ToTable ("tbl_cojBGTransferDoc");
            });
            modelBuilder.Entity<cojBGTransferDocItem> (entity => {
                entity.ToTable ("tbl_cojBGTransferDocItem");
            });

            //cojPolicy
            modelBuilder.Entity<cojBGPlanTransferAllot> (entity => {
                entity.ToTable ("tbl_cojBGPlanTransferAllot");
            });
            modelBuilder.Entity<cojPolicy> (entity => {
                entity.ToTable ("tbl_cojPolicy");
            });
            modelBuilder.Entity<cojPolicyItem> (entity => {
                entity.ToTable ("tbl_cojPolicyItem");
            });

            //cojNationStg
            modelBuilder.Entity<cojNationPlan> (entity => {
                entity.ToTable ("tbl_cojNationPlan");
            });
            modelBuilder.Entity<cojNationPlanStg> (entity => {
                entity.ToTable ("tbl_cojNationPlanStg");
            });
            modelBuilder.Entity<cojNationPlanGoal> (entity => {
                entity.ToTable ("tbl_cojNationPlanGoal");
            });
            modelBuilder.Entity<cojNationPlanGoalIndicator> (entity => {
                entity.ToTable ("tbl_cojNationPlanGoalIndicator");
            });
            modelBuilder.Entity<cojNationPlanGuildline> (entity => {
                entity.ToTable ("tbl_cojNationPlanGuildline");
            });
            modelBuilder.Entity<cojNationPlanGuildlineItem> (entity => {
                entity.ToTable ("tbl_cojNationPlanGuildlineItem");
            });
            modelBuilder.Entity<cojNationStg> (entity => {
                entity.ToTable ("tbl_cojNationStg");
            });
            modelBuilder.Entity<cojNationStgSector> (entity => {
                entity.ToTable ("tbl_cojNationStgSector");
            });
            modelBuilder.Entity<cojNationStgIssue> (entity => {
                entity.ToTable ("tbl_cojNationStgIssue");
            });
            modelBuilder.Entity<cojNationStgIndicator> (entity => {
                entity.ToTable ("tbl_cojNationStgIndicator");
            });

            //Revenue
            modelBuilder.Entity<cojRevenue> (entity => {
                entity.ToTable ("tbl_cojRevenue");
            });
            modelBuilder.Entity<cojRevenueAllot> (entity => {
                entity.ToTable ("tbl_cojRevenueAllot");
            });
            modelBuilder.Entity<cojReserve> (entity => {
                entity.ToTable ("tbl_cojReserve");
            });

            //RegionReserve
            modelBuilder.Entity<cojRegionReserveAllot> (entity => {
                entity.ToTable ("tbl_cojRegionReserveAllot");
            });
            modelBuilder.Entity<cojRegionReserveActivityItem> (entity => {
                entity.ToTable ("tbl_cojRegionReserveActivityItem");
            });
            modelBuilder.Entity<cojRegionReserveExtra> (entity => {
                entity.ToTable ("tbl_cojRegionReserveExtra");
            });
            modelBuilder.Entity<cojRegionAllot> (entity => {
                entity.ToTable ("tbl_cojRegionAllot");
            });
            modelBuilder.Entity<cojRegionAllotItem> (entity => {
                entity.ToTable ("tbl_cojRegionAllotItem");
            });

            //Integration
            modelBuilder.Entity<cojIntegration> (entity => {
                entity.ToTable ("tbl_cojIntegration");
            });
            modelBuilder.Entity<cojIntegrationAllot> (entity => {
                entity.ToTable ("tbl_cojIntegrationAllot");
            });
            modelBuilder.Entity<cojIntegrationAllotItem> (entity => {
                entity.ToTable ("tbl_cojIntegrationAllotItem");
            });

        }
    }
}