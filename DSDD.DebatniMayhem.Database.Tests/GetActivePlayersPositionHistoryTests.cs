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
    public class GetActivePlayersPositionHistoryTests : SqlDatabaseTestClass
    {

        public GetActivePlayersPositionHistoryTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetActivePlayersPositionHistoryTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetActivePlayersPositionHistoryTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetActivePlayersPositionHistoryTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GetActivePlayersPositionHistoryTest_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition inactivePlayerIsNotPart;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition checksumCondition1;
            this.dbo_GetActivePlayersPositionHistoryTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_GetActivePlayersPositionHistoryTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_GetActivePlayersPositionHistoryTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_GetActivePlayersPositionHistoryTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inactivePlayerIsNotPart = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            checksumCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            // 
            // dbo_GetActivePlayersPositionHistoryTest_TestAction
            // 
            dbo_GetActivePlayersPositionHistoryTest_TestAction.Conditions.Add(inactivePlayerIsNotPart);
            dbo_GetActivePlayersPositionHistoryTest_TestAction.Conditions.Add(checksumCondition1);
            resources.ApplyResources(dbo_GetActivePlayersPositionHistoryTest_TestAction, "dbo_GetActivePlayersPositionHistoryTest_TestAction");
            // 
            // dbo_GetActivePlayersPositionHistoryTest_PretestAction
            // 
            resources.ApplyResources(dbo_GetActivePlayersPositionHistoryTest_PretestAction, "dbo_GetActivePlayersPositionHistoryTest_PretestAction");
            // 
            // dbo_GetActivePlayersPositionHistoryTestData
            // 
            this.dbo_GetActivePlayersPositionHistoryTestData.PosttestAction = dbo_GetActivePlayersPositionHistoryTest_PosttestAction;
            this.dbo_GetActivePlayersPositionHistoryTestData.PretestAction = dbo_GetActivePlayersPositionHistoryTest_PretestAction;
            this.dbo_GetActivePlayersPositionHistoryTestData.TestAction = dbo_GetActivePlayersPositionHistoryTest_TestAction;
            // 
            // dbo_GetActivePlayersPositionHistoryTest_PosttestAction
            // 
            resources.ApplyResources(dbo_GetActivePlayersPositionHistoryTest_PosttestAction, "dbo_GetActivePlayersPositionHistoryTest_PosttestAction");
            // 
            // inactivePlayerIsNotPart
            // 
            inactivePlayerIsNotPart.Enabled = true;
            inactivePlayerIsNotPart.Name = "inactivePlayerIsNotPart";
            inactivePlayerIsNotPart.ResultSet = 1;
            inactivePlayerIsNotPart.RowCount = 2;
            // 
            // checksumCondition1
            // 
            checksumCondition1.Checksum = "290090745";
            checksumCondition1.Enabled = true;
            checksumCondition1.Name = "checksumCondition1";
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
        public void dbo_GetActivePlayersPositionHistoryTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_GetActivePlayersPositionHistoryTestData;
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

        private SqlDatabaseTestActions dbo_GetActivePlayersPositionHistoryTestData;
    }
}
