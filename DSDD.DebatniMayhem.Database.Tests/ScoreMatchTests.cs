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
    public class ScoreMatchTests : SqlDatabaseTestClass
    {

        public ScoreMatchTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_ScoreMatchTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreMatchTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition checkSum;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_ScoreMatchTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_ScoreMatchTest_PosttestAction;
            this.dbo_ScoreMatchTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_ScoreMatchTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            checkSum = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            dbo_ScoreMatchTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_ScoreMatchTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // dbo_ScoreMatchTest_TestAction
            // 
            dbo_ScoreMatchTest_TestAction.Conditions.Add(checkSum);
            resources.ApplyResources(dbo_ScoreMatchTest_TestAction, "dbo_ScoreMatchTest_TestAction");
            // 
            // checkSum
            // 
            checkSum.Checksum = "1675868850";
            checkSum.Enabled = true;
            checkSum.Name = "checkSum";
            // 
            // dbo_ScoreMatchTest_PretestAction
            // 
            resources.ApplyResources(dbo_ScoreMatchTest_PretestAction, "dbo_ScoreMatchTest_PretestAction");
            // 
            // dbo_ScoreMatchTest_PosttestAction
            // 
            resources.ApplyResources(dbo_ScoreMatchTest_PosttestAction, "dbo_ScoreMatchTest_PosttestAction");
            // 
            // dbo_ScoreMatchTestData
            // 
            this.dbo_ScoreMatchTestData.PosttestAction = dbo_ScoreMatchTest_PosttestAction;
            this.dbo_ScoreMatchTestData.PretestAction = dbo_ScoreMatchTest_PretestAction;
            this.dbo_ScoreMatchTestData.TestAction = dbo_ScoreMatchTest_TestAction;
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
        public void dbo_ScoreMatchTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_ScoreMatchTestData;
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
        private SqlDatabaseTestActions dbo_ScoreMatchTestData;
    }
}
