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
    public class GetScoreChangeFromSpeakerPointsTests : SqlDatabaseTestClass
    {

        public GetScoreChangeFromSpeakerPointsTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetScoreChangeFromSpeakerPointsTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetScoreChangeFromSpeakerPointsTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition sp70;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition sp80;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition sp70_2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetScoreChangeFromSpeakerPointsTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetScoreChangeFromSpeakerPointsTest_PosttestAction;
            this.dbo_GetScoreChangeFromSpeakerPointsTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_GetScoreChangeFromSpeakerPointsTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            sp70 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            sp80 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            sp70_2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            dbo_GetScoreChangeFromSpeakerPointsTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_GetScoreChangeFromSpeakerPointsTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // dbo_GetScoreChangeFromSpeakerPointsTest_TestAction
            // 
            dbo_GetScoreChangeFromSpeakerPointsTest_TestAction.Conditions.Add(sp70);
            dbo_GetScoreChangeFromSpeakerPointsTest_TestAction.Conditions.Add(sp80);
            dbo_GetScoreChangeFromSpeakerPointsTest_TestAction.Conditions.Add(sp70_2);
            resources.ApplyResources(dbo_GetScoreChangeFromSpeakerPointsTest_TestAction, "dbo_GetScoreChangeFromSpeakerPointsTest_TestAction");
            // 
            // sp70
            // 
            sp70.ColumnNumber = 1;
            sp70.Enabled = true;
            sp70.ExpectedValue = "0";
            sp70.Name = "sp70";
            sp70.NullExpected = false;
            sp70.ResultSet = 1;
            sp70.RowNumber = 1;
            // 
            // sp80
            // 
            sp80.ColumnNumber = 1;
            sp80.Enabled = true;
            sp80.ExpectedValue = "20";
            sp80.Name = "sp80";
            sp80.NullExpected = false;
            sp80.ResultSet = 2;
            sp80.RowNumber = 1;
            // 
            // sp70_2
            // 
            sp70_2.ColumnNumber = 1;
            sp70_2.Enabled = true;
            sp70_2.ExpectedValue = "-40";
            sp70_2.Name = "sp70_2";
            sp70_2.NullExpected = false;
            sp70_2.ResultSet = 3;
            sp70_2.RowNumber = 1;
            // 
            // dbo_GetScoreChangeFromSpeakerPointsTest_PretestAction
            // 
            resources.ApplyResources(dbo_GetScoreChangeFromSpeakerPointsTest_PretestAction, "dbo_GetScoreChangeFromSpeakerPointsTest_PretestAction");
            // 
            // dbo_GetScoreChangeFromSpeakerPointsTest_PosttestAction
            // 
            resources.ApplyResources(dbo_GetScoreChangeFromSpeakerPointsTest_PosttestAction, "dbo_GetScoreChangeFromSpeakerPointsTest_PosttestAction");
            // 
            // dbo_GetScoreChangeFromSpeakerPointsTestData
            // 
            this.dbo_GetScoreChangeFromSpeakerPointsTestData.PosttestAction = dbo_GetScoreChangeFromSpeakerPointsTest_PosttestAction;
            this.dbo_GetScoreChangeFromSpeakerPointsTestData.PretestAction = dbo_GetScoreChangeFromSpeakerPointsTest_PretestAction;
            this.dbo_GetScoreChangeFromSpeakerPointsTestData.TestAction = dbo_GetScoreChangeFromSpeakerPointsTest_TestAction;
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
        public void dbo_GetScoreChangeFromSpeakerPointsTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_GetScoreChangeFromSpeakerPointsTestData;
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
        private SqlDatabaseTestActions dbo_GetScoreChangeFromSpeakerPointsTestData;
    }
}
