using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSDD.DebatniMayhem.Database.Tests
{
    [TestClass()]
    public class RevealActiveRoundInfoSlideTests : SqlDatabaseTestClass
    {

        public RevealActiveRoundInfoSlideTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction NoOngoinground_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevealActiveRoundInfoSlideTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundDoesNotHaveInfoSlide_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundDoesNotHaveInfoSlide_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundDoesNotHaveInfoSlide_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition3;
            this.NoOngoingroundData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.OngoingRoundDoesNotHaveInfoSlideData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.OngoingRoundHasInfoSlideData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            NoOngoinground_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundDoesNotHaveInfoSlide_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundDoesNotHaveInfoSlide_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundDoesNotHaveInfoSlide_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OngoingRoundHasInfoSlide_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundHasInfoSlide_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundHasInfoSlide_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // NoOngoinground_TestAction
            // 
            NoOngoinground_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(NoOngoinground_TestAction, "NoOngoinground_TestAction");
            // 
            // NoOngoingroundData
            // 
            this.NoOngoingroundData.PosttestAction = null;
            this.NoOngoingroundData.PretestAction = null;
            this.NoOngoingroundData.TestAction = NoOngoinground_TestAction;
            // 
            // OngoingRoundDoesNotHaveInfoSlideData
            // 
            this.OngoingRoundDoesNotHaveInfoSlideData.PosttestAction = OngoingRoundDoesNotHaveInfoSlide_PosttestAction;
            this.OngoingRoundDoesNotHaveInfoSlideData.PretestAction = OngoingRoundDoesNotHaveInfoSlide_PretestAction;
            this.OngoingRoundDoesNotHaveInfoSlideData.TestAction = OngoingRoundDoesNotHaveInfoSlide_TestAction;
            // 
            // OngoingRoundDoesNotHaveInfoSlide_TestAction
            // 
            OngoingRoundDoesNotHaveInfoSlide_TestAction.Conditions.Add(scalarValueCondition2);
            resources.ApplyResources(OngoingRoundDoesNotHaveInfoSlide_TestAction, "OngoingRoundDoesNotHaveInfoSlide_TestAction");
            // 
            // OngoingRoundDoesNotHaveInfoSlide_PretestAction
            // 
            resources.ApplyResources(OngoingRoundDoesNotHaveInfoSlide_PretestAction, "OngoingRoundDoesNotHaveInfoSlide_PretestAction");
            // 
            // OngoingRoundDoesNotHaveInfoSlide_PosttestAction
            // 
            resources.ApplyResources(OngoingRoundDoesNotHaveInfoSlide_PosttestAction, "OngoingRoundDoesNotHaveInfoSlide_PosttestAction");
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 1;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "V danou chvíli neprobíhá žádné kolo!";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 1;
            scalarValueCondition1.RowNumber = 1;
            // 
            // scalarValueCondition2
            // 
            scalarValueCondition2.ColumnNumber = 1;
            scalarValueCondition2.Enabled = true;
            scalarValueCondition2.ExpectedValue = "Toto kolo nemá info slide a je tedy potřeba aktivovat tezi rovnou!";
            scalarValueCondition2.Name = "scalarValueCondition2";
            scalarValueCondition2.NullExpected = false;
            scalarValueCondition2.ResultSet = 1;
            scalarValueCondition2.RowNumber = 1;
            // 
            // OngoingRoundHasInfoSlideData
            // 
            this.OngoingRoundHasInfoSlideData.PosttestAction = OngoingRoundHasInfoSlide_PosttestAction;
            this.OngoingRoundHasInfoSlideData.PretestAction = OngoingRoundHasInfoSlide_PretestAction;
            this.OngoingRoundHasInfoSlideData.TestAction = OngoingRoundHasInfoSlide_TestAction;
            // 
            // OngoingRoundHasInfoSlide_TestAction
            // 
            OngoingRoundHasInfoSlide_TestAction.Conditions.Add(scalarValueCondition3);
            resources.ApplyResources(OngoingRoundHasInfoSlide_TestAction, "OngoingRoundHasInfoSlide_TestAction");
            // 
            // OngoingRoundHasInfoSlide_PretestAction
            // 
            resources.ApplyResources(OngoingRoundHasInfoSlide_PretestAction, "OngoingRoundHasInfoSlide_PretestAction");
            // 
            // OngoingRoundHasInfoSlide_PosttestAction
            // 
            resources.ApplyResources(OngoingRoundHasInfoSlide_PosttestAction, "OngoingRoundHasInfoSlide_PosttestAction");
            // 
            // scalarValueCondition3
            // 
            scalarValueCondition3.ColumnNumber = 1;
            scalarValueCondition3.Enabled = true;
            scalarValueCondition3.ExpectedValue = "true";
            scalarValueCondition3.Name = "scalarValueCondition3";
            scalarValueCondition3.NullExpected = false;
            scalarValueCondition3.ResultSet = 1;
            scalarValueCondition3.RowNumber = 1;
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
        public void NoOngoinground()
        {
            SqlDatabaseTestActions testActions = this.NoOngoingroundData;
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
        public void OngoingRoundDoesNotHaveInfoSlide()
        {
            SqlDatabaseTestActions testActions = this.OngoingRoundDoesNotHaveInfoSlideData;
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
        public void OngoingRoundHasInfoSlide()
        {
            SqlDatabaseTestActions testActions = this.OngoingRoundHasInfoSlideData;
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


        private SqlDatabaseTestActions NoOngoingroundData;
        private SqlDatabaseTestActions OngoingRoundDoesNotHaveInfoSlideData;
        private SqlDatabaseTestActions OngoingRoundHasInfoSlideData;
    }
}
