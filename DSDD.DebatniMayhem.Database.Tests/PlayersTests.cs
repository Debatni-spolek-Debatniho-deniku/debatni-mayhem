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
    public class PlayersTests : SqlDatabaseTestClass
    {

        public PlayersTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction PlaceholderPlayerIsZeroed_Insert_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction PlaceholderPlayerIsZeroed_Insert_PosttestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction PlayerholderPlayerIsZeroed_Update_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction PlayerholderPlayerIsZeroed_Update_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction PlayerholderPlayerIsZeroed_Update_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition checksumCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition checksumCondition2;
            this.PlaceholderPlayerIsZeroed_InsertData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.PlayerholderPlayerIsZeroed_UpdateData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            PlaceholderPlayerIsZeroed_Insert_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            PlaceholderPlayerIsZeroed_Insert_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            PlayerholderPlayerIsZeroed_Update_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            PlayerholderPlayerIsZeroed_Update_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            PlayerholderPlayerIsZeroed_Update_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            checksumCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            checksumCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            // 
            // PlaceholderPlayerIsZeroed_InsertData
            // 
            this.PlaceholderPlayerIsZeroed_InsertData.PosttestAction = PlaceholderPlayerIsZeroed_Insert_PosttestAction;
            this.PlaceholderPlayerIsZeroed_InsertData.PretestAction = null;
            this.PlaceholderPlayerIsZeroed_InsertData.TestAction = PlaceholderPlayerIsZeroed_Insert_TestAction;
            // 
            // PlaceholderPlayerIsZeroed_Insert_TestAction
            // 
            PlaceholderPlayerIsZeroed_Insert_TestAction.Conditions.Add(checksumCondition1);
            resources.ApplyResources(PlaceholderPlayerIsZeroed_Insert_TestAction, "PlaceholderPlayerIsZeroed_Insert_TestAction");
            // 
            // PlaceholderPlayerIsZeroed_Insert_PosttestAction
            // 
            resources.ApplyResources(PlaceholderPlayerIsZeroed_Insert_PosttestAction, "PlaceholderPlayerIsZeroed_Insert_PosttestAction");
            // 
            // PlayerholderPlayerIsZeroed_UpdateData
            // 
            this.PlayerholderPlayerIsZeroed_UpdateData.PosttestAction = PlayerholderPlayerIsZeroed_Update_PosttestAction;
            this.PlayerholderPlayerIsZeroed_UpdateData.PretestAction = PlayerholderPlayerIsZeroed_Update_PretestAction;
            this.PlayerholderPlayerIsZeroed_UpdateData.TestAction = PlayerholderPlayerIsZeroed_Update_TestAction;
            // 
            // PlayerholderPlayerIsZeroed_Update_TestAction
            // 
            PlayerholderPlayerIsZeroed_Update_TestAction.Conditions.Add(checksumCondition2);
            resources.ApplyResources(PlayerholderPlayerIsZeroed_Update_TestAction, "PlayerholderPlayerIsZeroed_Update_TestAction");
            // 
            // PlayerholderPlayerIsZeroed_Update_PretestAction
            // 
            resources.ApplyResources(PlayerholderPlayerIsZeroed_Update_PretestAction, "PlayerholderPlayerIsZeroed_Update_PretestAction");
            // 
            // PlayerholderPlayerIsZeroed_Update_PosttestAction
            // 
            resources.ApplyResources(PlayerholderPlayerIsZeroed_Update_PosttestAction, "PlayerholderPlayerIsZeroed_Update_PosttestAction");
            // 
            // checksumCondition1
            // 
            checksumCondition1.Checksum = "-2030447949";
            checksumCondition1.Enabled = true;
            checksumCondition1.Name = "checksumCondition1";
            // 
            // checksumCondition2
            // 
            checksumCondition2.Checksum = "-2030447949";
            checksumCondition2.Enabled = true;
            checksumCondition2.Name = "checksumCondition2";
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
        public void PlaceholderPlayerIsZeroed_Insert()
        {
            SqlDatabaseTestActions testActions = this.PlaceholderPlayerIsZeroed_InsertData;
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
        public void PlayerholderPlayerIsZeroed_Update()
        {
            SqlDatabaseTestActions testActions = this.PlayerholderPlayerIsZeroed_UpdateData;
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

        private SqlDatabaseTestActions PlaceholderPlayerIsZeroed_InsertData;
        private SqlDatabaseTestActions PlayerholderPlayerIsZeroed_UpdateData;
    }
}
