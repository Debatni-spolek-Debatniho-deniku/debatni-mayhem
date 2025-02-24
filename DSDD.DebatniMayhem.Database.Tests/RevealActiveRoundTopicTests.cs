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
    public class RevealActiveRoundTopicTests : SqlDatabaseTestClass
    {

        public RevealActiveRoundTopicTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_RevealActiveRoundTopicTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_RevealActiveRoundTopicTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_RevealActiveRoundTopicTest_PosttestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevealActiveRoundTopicTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction NoOngoingRound_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            this.dbo_RevealActiveRoundTopicTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.NoOngoingRoundData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_RevealActiveRoundTopicTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_RevealActiveRoundTopicTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_RevealActiveRoundTopicTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            NoOngoingRound_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_RevealActiveRoundTopicTestData
            // 
            this.dbo_RevealActiveRoundTopicTestData.PosttestAction = dbo_RevealActiveRoundTopicTest_PosttestAction;
            this.dbo_RevealActiveRoundTopicTestData.PretestAction = dbo_RevealActiveRoundTopicTest_PretestAction;
            this.dbo_RevealActiveRoundTopicTestData.TestAction = dbo_RevealActiveRoundTopicTest_TestAction;
            // 
            // dbo_RevealActiveRoundTopicTest_TestAction
            // 
            dbo_RevealActiveRoundTopicTest_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(dbo_RevealActiveRoundTopicTest_TestAction, "dbo_RevealActiveRoundTopicTest_TestAction");
            // 
            // dbo_RevealActiveRoundTopicTest_PretestAction
            // 
            resources.ApplyResources(dbo_RevealActiveRoundTopicTest_PretestAction, "dbo_RevealActiveRoundTopicTest_PretestAction");
            // 
            // dbo_RevealActiveRoundTopicTest_PosttestAction
            // 
            resources.ApplyResources(dbo_RevealActiveRoundTopicTest_PosttestAction, "dbo_RevealActiveRoundTopicTest_PosttestAction");
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 1;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "true";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 1;
            scalarValueCondition1.RowNumber = 1;
            // 
            // NoOngoingRoundData
            // 
            this.NoOngoingRoundData.PosttestAction = null;
            this.NoOngoingRoundData.PretestAction = null;
            this.NoOngoingRoundData.TestAction = NoOngoingRound_TestAction;
            // 
            // NoOngoingRound_TestAction
            // 
            NoOngoingRound_TestAction.Conditions.Add(scalarValueCondition2);
            resources.ApplyResources(NoOngoingRound_TestAction, "NoOngoingRound_TestAction");
            // 
            // scalarValueCondition2
            // 
            scalarValueCondition2.ColumnNumber = 1;
            scalarValueCondition2.Enabled = true;
            scalarValueCondition2.ExpectedValue = "V danou chvíli neprobíhá žádné kolo!";
            scalarValueCondition2.Name = "scalarValueCondition2";
            scalarValueCondition2.NullExpected = false;
            scalarValueCondition2.ResultSet = 1;
            scalarValueCondition2.RowNumber = 1;
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
        public void dbo_RevealActiveRoundTopicTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_RevealActiveRoundTopicTestData;
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
        [TestMethod()]
        public void NoOngoingRound()
        {
            SqlDatabaseTestActions testActions = this.NoOngoingRoundData;
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

        private SqlDatabaseTestActions dbo_RevealActiveRoundTopicTestData;
        private SqlDatabaseTestActions NoOngoingRoundData;
    }
}
