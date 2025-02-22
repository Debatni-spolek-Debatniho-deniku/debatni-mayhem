using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DSDD.DebatniMayhem.Database.Tests
{
    [TestClass()]
    public class CreateNewRoundTests : SqlDatabaseTestClass
    {

        public CreateNewRoundTests()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_CreateNewRoundTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_CreateNewRoundTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_CreateNewRoundTest_PosttestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewRoundTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition numberOfMatches;
            this.dbo_CreateNewRoundTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_CreateNewRoundTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_CreateNewRoundTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_CreateNewRoundTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            numberOfMatches = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            // 
            // dbo_CreateNewRoundTestData
            // 
            this.dbo_CreateNewRoundTestData.PosttestAction = dbo_CreateNewRoundTest_PosttestAction;
            this.dbo_CreateNewRoundTestData.PretestAction = dbo_CreateNewRoundTest_PretestAction;
            this.dbo_CreateNewRoundTestData.TestAction = dbo_CreateNewRoundTest_TestAction;
            // 
            // dbo_CreateNewRoundTest_TestAction
            // 
            dbo_CreateNewRoundTest_TestAction.Conditions.Add(numberOfMatches);
            resources.ApplyResources(dbo_CreateNewRoundTest_TestAction, "dbo_CreateNewRoundTest_TestAction");
            // 
            // dbo_CreateNewRoundTest_PretestAction
            // 
            resources.ApplyResources(dbo_CreateNewRoundTest_PretestAction, "dbo_CreateNewRoundTest_PretestAction");
            // 
            // dbo_CreateNewRoundTest_PosttestAction
            // 
            resources.ApplyResources(dbo_CreateNewRoundTest_PosttestAction, "dbo_CreateNewRoundTest_PosttestAction");
            // 
            // numberOfMatches
            // 
            numberOfMatches.Enabled = true;
            numberOfMatches.Name = "numberOfMatches";
            numberOfMatches.ResultSet = 1;
            numberOfMatches.RowCount = 3;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void dbo_CreateNewRoundTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_CreateNewRoundTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        private SqlDatabaseTestActions dbo_CreateNewRoundTestData;
    }
}
