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
    public class GetScoreChangeFromPointsTests : SqlDatabaseTestClass
    {

        public GetScoreChangeFromPointsTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetScoreChangeFromPointsTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetScoreChangeFromPointsTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition equal;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition shouldBeThird;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition shouldBeLast;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetScoreChangeFromPointsTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetScoreChangeFromPointsTest_PosttestAction;
            this.dbo_GetScoreChangeFromPointsTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_GetScoreChangeFromPointsTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            equal = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            shouldBeThird = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            shouldBeLast = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            dbo_GetScoreChangeFromPointsTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_GetScoreChangeFromPointsTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // dbo_GetScoreChangeFromPointsTest_TestAction
            // 
            dbo_GetScoreChangeFromPointsTest_TestAction.Conditions.Add(equal);
            dbo_GetScoreChangeFromPointsTest_TestAction.Conditions.Add(shouldBeThird);
            dbo_GetScoreChangeFromPointsTest_TestAction.Conditions.Add(shouldBeLast);
            resources.ApplyResources(dbo_GetScoreChangeFromPointsTest_TestAction, "dbo_GetScoreChangeFromPointsTest_TestAction");
            // 
            // equal
            // 
            equal.ColumnNumber = 1;
            equal.Enabled = true;
            equal.ExpectedValue = "30";
            equal.Name = "equal";
            equal.NullExpected = false;
            equal.ResultSet = 1;
            equal.RowNumber = 1;
            // 
            // shouldBeThird
            // 
            shouldBeThird.ColumnNumber = 1;
            shouldBeThird.Enabled = true;
            shouldBeThird.ExpectedValue = "-3";
            shouldBeThird.Name = "shouldBeThird";
            shouldBeThird.NullExpected = false;
            shouldBeThird.ResultSet = 2;
            shouldBeThird.RowNumber = 1;
            // 
            // shouldBeLast
            // 
            shouldBeLast.ColumnNumber = 1;
            shouldBeLast.Enabled = true;
            shouldBeLast.ExpectedValue = "-54";
            shouldBeLast.Name = "shouldBeLast";
            shouldBeLast.NullExpected = false;
            shouldBeLast.ResultSet = 3;
            shouldBeLast.RowNumber = 1;
            // 
            // dbo_GetScoreChangeFromPointsTest_PretestAction
            // 
            resources.ApplyResources(dbo_GetScoreChangeFromPointsTest_PretestAction, "dbo_GetScoreChangeFromPointsTest_PretestAction");
            // 
            // dbo_GetScoreChangeFromPointsTest_PosttestAction
            // 
            resources.ApplyResources(dbo_GetScoreChangeFromPointsTest_PosttestAction, "dbo_GetScoreChangeFromPointsTest_PosttestAction");
            // 
            // dbo_GetScoreChangeFromPointsTestData
            // 
            this.dbo_GetScoreChangeFromPointsTestData.PosttestAction = dbo_GetScoreChangeFromPointsTest_PosttestAction;
            this.dbo_GetScoreChangeFromPointsTestData.PretestAction = dbo_GetScoreChangeFromPointsTest_PretestAction;
            this.dbo_GetScoreChangeFromPointsTestData.TestAction = dbo_GetScoreChangeFromPointsTest_TestAction;
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
        public void dbo_GetScoreChangeFromPointsTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_GetScoreChangeFromPointsTestData;
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
        private SqlDatabaseTestActions dbo_GetScoreChangeFromPointsTestData;
    }
}
