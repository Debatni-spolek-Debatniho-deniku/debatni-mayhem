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
    public class GetExpectedSpeakerPointsTests : SqlDatabaseTestClass
    {

        public GetExpectedSpeakerPointsTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetExpectedSpeakerPointsTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetExpectedSpeakerPointsTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition s450;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition s999;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition s1000;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition s1850;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition s999999;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetExpectedSpeakerPointsTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetExpectedSpeakerPointsTest_PosttestAction;
            this.dbo_GetExpectedSpeakerPointsTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_GetExpectedSpeakerPointsTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            s450 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            s999 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            s1000 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            s1850 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            s999999 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            dbo_GetExpectedSpeakerPointsTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_GetExpectedSpeakerPointsTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // dbo_GetExpectedSpeakerPointsTest_TestAction
            // 
            dbo_GetExpectedSpeakerPointsTest_TestAction.Conditions.Add(s450);
            dbo_GetExpectedSpeakerPointsTest_TestAction.Conditions.Add(s999);
            dbo_GetExpectedSpeakerPointsTest_TestAction.Conditions.Add(s1000);
            dbo_GetExpectedSpeakerPointsTest_TestAction.Conditions.Add(s1850);
            dbo_GetExpectedSpeakerPointsTest_TestAction.Conditions.Add(s999999);
            resources.ApplyResources(dbo_GetExpectedSpeakerPointsTest_TestAction, "dbo_GetExpectedSpeakerPointsTest_TestAction");
            // 
            // s450
            // 
            s450.ColumnNumber = 1;
            s450.Enabled = true;
            s450.ExpectedValue = "60";
            s450.Name = "s450";
            s450.NullExpected = false;
            s450.ResultSet = 1;
            s450.RowNumber = 1;
            // 
            // s999
            // 
            s999.ColumnNumber = 1;
            s999.Enabled = true;
            s999.ExpectedValue = "65";
            s999.Name = "s999";
            s999.NullExpected = false;
            s999.ResultSet = 2;
            s999.RowNumber = 1;
            // 
            // s1000
            // 
            s1000.ColumnNumber = 1;
            s1000.Enabled = true;
            s1000.ExpectedValue = "70";
            s1000.Name = "s1000";
            s1000.NullExpected = false;
            s1000.ResultSet = 3;
            s1000.RowNumber = 1;
            // 
            // s1850
            // 
            s1850.ColumnNumber = 1;
            s1850.Enabled = true;
            s1850.ExpectedValue = "70";
            s1850.Name = "s1850";
            s1850.NullExpected = false;
            s1850.ResultSet = 4;
            s1850.RowNumber = 1;
            // 
            // s999999
            // 
            s999999.ColumnNumber = 1;
            s999999.Enabled = true;
            s999999.ExpectedValue = "80";
            s999999.Name = "s999999";
            s999999.NullExpected = false;
            s999999.ResultSet = 5;
            s999999.RowNumber = 1;
            // 
            // dbo_GetExpectedSpeakerPointsTest_PretestAction
            // 
            resources.ApplyResources(dbo_GetExpectedSpeakerPointsTest_PretestAction, "dbo_GetExpectedSpeakerPointsTest_PretestAction");
            // 
            // dbo_GetExpectedSpeakerPointsTest_PosttestAction
            // 
            resources.ApplyResources(dbo_GetExpectedSpeakerPointsTest_PosttestAction, "dbo_GetExpectedSpeakerPointsTest_PosttestAction");
            // 
            // dbo_GetExpectedSpeakerPointsTestData
            // 
            this.dbo_GetExpectedSpeakerPointsTestData.PosttestAction = dbo_GetExpectedSpeakerPointsTest_PosttestAction;
            this.dbo_GetExpectedSpeakerPointsTestData.PretestAction = dbo_GetExpectedSpeakerPointsTest_PretestAction;
            this.dbo_GetExpectedSpeakerPointsTestData.TestAction = dbo_GetExpectedSpeakerPointsTest_TestAction;
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
        public void dbo_GetExpectedSpeakerPointsTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_GetExpectedSpeakerPointsTestData;
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
        private SqlDatabaseTestActions dbo_GetExpectedSpeakerPointsTestData;
    }
}
