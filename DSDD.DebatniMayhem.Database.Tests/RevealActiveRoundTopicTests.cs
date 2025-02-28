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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundDoesNotHaveInfoSlide_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevealActiveRoundTopicTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundDoesNotHaveInfoSlide_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundDoesNotHaveInfoSlide_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction NoOngoingRound_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_NotRevealed_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_NotRevealed_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_Revealed_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_Revealed_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_NotRevealed_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundHasInfoSlide_Revealed_PretestAction;
            this.OngoingRoundDoesNotHaveInfoSlideData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.NoOngoingRoundData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.OngoingRoundHasInfoSlide_NotRevealedData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.OngoingRoundHasInfoSlide_RevealedData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            OngoingRoundDoesNotHaveInfoSlide_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OngoingRoundDoesNotHaveInfoSlide_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundDoesNotHaveInfoSlide_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            NoOngoingRound_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OngoingRoundHasInfoSlide_NotRevealed_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OngoingRoundHasInfoSlide_NotRevealed_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundHasInfoSlide_Revealed_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OngoingRoundHasInfoSlide_Revealed_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundHasInfoSlide_NotRevealed_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundHasInfoSlide_Revealed_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // OngoingRoundDoesNotHaveInfoSlide_TestAction
            // 
            OngoingRoundDoesNotHaveInfoSlide_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(OngoingRoundDoesNotHaveInfoSlide_TestAction, "OngoingRoundDoesNotHaveInfoSlide_TestAction");
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
            // OngoingRoundDoesNotHaveInfoSlide_PretestAction
            // 
            resources.ApplyResources(OngoingRoundDoesNotHaveInfoSlide_PretestAction, "OngoingRoundDoesNotHaveInfoSlide_PretestAction");
            // 
            // OngoingRoundDoesNotHaveInfoSlide_PosttestAction
            // 
            resources.ApplyResources(OngoingRoundDoesNotHaveInfoSlide_PosttestAction, "OngoingRoundDoesNotHaveInfoSlide_PosttestAction");
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
            // 
            // OngoingRoundHasInfoSlide_NotRevealed_TestAction
            // 
            OngoingRoundHasInfoSlide_NotRevealed_TestAction.Conditions.Add(scalarValueCondition3);
            resources.ApplyResources(OngoingRoundHasInfoSlide_NotRevealed_TestAction, "OngoingRoundHasInfoSlide_NotRevealed_TestAction");
            // 
            // scalarValueCondition3
            // 
            scalarValueCondition3.ColumnNumber = 1;
            scalarValueCondition3.Enabled = true;
            scalarValueCondition3.ExpectedValue = "Toto kolo obsahuje info slide a je tedy nezbytné nejprve odhalit infoslide!";
            scalarValueCondition3.Name = "scalarValueCondition3";
            scalarValueCondition3.NullExpected = false;
            scalarValueCondition3.ResultSet = 1;
            scalarValueCondition3.RowNumber = 1;
            // 
            // OngoingRoundHasInfoSlide_NotRevealed_PretestAction
            // 
            resources.ApplyResources(OngoingRoundHasInfoSlide_NotRevealed_PretestAction, "OngoingRoundHasInfoSlide_NotRevealed_PretestAction");
            // 
            // OngoingRoundHasInfoSlide_Revealed_TestAction
            // 
            OngoingRoundHasInfoSlide_Revealed_TestAction.Conditions.Add(scalarValueCondition4);
            resources.ApplyResources(OngoingRoundHasInfoSlide_Revealed_TestAction, "OngoingRoundHasInfoSlide_Revealed_TestAction");
            // 
            // scalarValueCondition4
            // 
            scalarValueCondition4.ColumnNumber = 1;
            scalarValueCondition4.Enabled = true;
            scalarValueCondition4.ExpectedValue = "true";
            scalarValueCondition4.Name = "scalarValueCondition4";
            scalarValueCondition4.NullExpected = false;
            scalarValueCondition4.ResultSet = 1;
            scalarValueCondition4.RowNumber = 1;
            // 
            // OngoingRoundHasInfoSlide_Revealed_PosttestAction
            // 
            resources.ApplyResources(OngoingRoundHasInfoSlide_Revealed_PosttestAction, "OngoingRoundHasInfoSlide_Revealed_PosttestAction");
            // 
            // OngoingRoundHasInfoSlide_NotRevealed_PosttestAction
            // 
            resources.ApplyResources(OngoingRoundHasInfoSlide_NotRevealed_PosttestAction, "OngoingRoundHasInfoSlide_NotRevealed_PosttestAction");
            // 
            // OngoingRoundHasInfoSlide_Revealed_PretestAction
            // 
            resources.ApplyResources(OngoingRoundHasInfoSlide_Revealed_PretestAction, "OngoingRoundHasInfoSlide_Revealed_PretestAction");
            // 
            // OngoingRoundDoesNotHaveInfoSlideData
            // 
            this.OngoingRoundDoesNotHaveInfoSlideData.PosttestAction = OngoingRoundDoesNotHaveInfoSlide_PosttestAction;
            this.OngoingRoundDoesNotHaveInfoSlideData.PretestAction = OngoingRoundDoesNotHaveInfoSlide_PretestAction;
            this.OngoingRoundDoesNotHaveInfoSlideData.TestAction = OngoingRoundDoesNotHaveInfoSlide_TestAction;
            // 
            // NoOngoingRoundData
            // 
            this.NoOngoingRoundData.PosttestAction = null;
            this.NoOngoingRoundData.PretestAction = null;
            this.NoOngoingRoundData.TestAction = NoOngoingRound_TestAction;
            // 
            // OngoingRoundHasInfoSlide_NotRevealedData
            // 
            this.OngoingRoundHasInfoSlide_NotRevealedData.PosttestAction = OngoingRoundHasInfoSlide_NotRevealed_PosttestAction;
            this.OngoingRoundHasInfoSlide_NotRevealedData.PretestAction = OngoingRoundHasInfoSlide_NotRevealed_PretestAction;
            this.OngoingRoundHasInfoSlide_NotRevealedData.TestAction = OngoingRoundHasInfoSlide_NotRevealed_TestAction;
            // 
            // OngoingRoundHasInfoSlide_RevealedData
            // 
            this.OngoingRoundHasInfoSlide_RevealedData.PosttestAction = OngoingRoundHasInfoSlide_Revealed_PosttestAction;
            this.OngoingRoundHasInfoSlide_RevealedData.PretestAction = OngoingRoundHasInfoSlide_Revealed_PretestAction;
            this.OngoingRoundHasInfoSlide_RevealedData.TestAction = OngoingRoundHasInfoSlide_Revealed_TestAction;
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
        [TestMethod()]
        public void OngoingRoundHasInfoSlide_NotRevealed()
        {
            SqlDatabaseTestActions testActions = this.OngoingRoundHasInfoSlide_NotRevealedData;
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
        public void OngoingRoundHasInfoSlide_Revealed()
        {
            SqlDatabaseTestActions testActions = this.OngoingRoundHasInfoSlide_RevealedData;
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



        private SqlDatabaseTestActions OngoingRoundDoesNotHaveInfoSlideData;
        private SqlDatabaseTestActions NoOngoingRoundData;
        private SqlDatabaseTestActions OngoingRoundHasInfoSlide_NotRevealedData;
        private SqlDatabaseTestActions OngoingRoundHasInfoSlide_RevealedData;
    }
}
