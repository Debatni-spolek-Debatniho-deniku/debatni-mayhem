﻿using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
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
    public class DeleteRoundTests : SqlDatabaseTestClass
    {

        public DeleteRoundTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_DeleteRoundTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteRoundTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition preExec;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition postExec;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_DeleteRoundTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_DeleteRoundTest_PosttestAction;
            this.dbo_DeleteRoundTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_DeleteRoundTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            preExec = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            postExec = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            dbo_DeleteRoundTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_DeleteRoundTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // dbo_DeleteRoundTest_TestAction
            // 
            dbo_DeleteRoundTest_TestAction.Conditions.Add(preExec);
            dbo_DeleteRoundTest_TestAction.Conditions.Add(postExec);
            resources.ApplyResources(dbo_DeleteRoundTest_TestAction, "dbo_DeleteRoundTest_TestAction");
            // 
            // preExec
            // 
            preExec.Enabled = true;
            preExec.Name = "preExec";
            preExec.ResultSet = 1;
            preExec.RowCount = 2;
            // 
            // postExec
            // 
            postExec.Enabled = true;
            postExec.Name = "postExec";
            postExec.ResultSet = 2;
            postExec.RowCount = 0;
            // 
            // dbo_DeleteRoundTest_PretestAction
            // 
            resources.ApplyResources(dbo_DeleteRoundTest_PretestAction, "dbo_DeleteRoundTest_PretestAction");
            // 
            // dbo_DeleteRoundTest_PosttestAction
            // 
            resources.ApplyResources(dbo_DeleteRoundTest_PosttestAction, "dbo_DeleteRoundTest_PosttestAction");
            // 
            // dbo_DeleteRoundTestData
            // 
            this.dbo_DeleteRoundTestData.PosttestAction = dbo_DeleteRoundTest_PosttestAction;
            this.dbo_DeleteRoundTestData.PretestAction = dbo_DeleteRoundTest_PretestAction;
            this.dbo_DeleteRoundTestData.TestAction = dbo_DeleteRoundTest_TestAction;
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
        public void dbo_DeleteRoundTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_DeleteRoundTestData;
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
        private SqlDatabaseTestActions dbo_DeleteRoundTestData;
    }
}
