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
    public class ActiveRoundTests : SqlDatabaseTestClass
    {

        public ActiveRoundTests()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ImplicitNext_NoOngoingRound_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveRoundTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundNotScored_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundNotScored_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OngoingRoundNotScored_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OnogingRoundIsNewest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OnogingRoundIsNewest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction OnogingRoundIsNewest_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ExplicitlyActivateRound_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ExplicitlyActivateRound_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ExplicitlyActivateRound_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ImplicitlyActivateRound_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ImplicitlyActivateRound_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction ImplicitlyActivateRound_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction NewRoundHasHiddenTopic_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction NewRoundHasHiddenTopic_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction NewRoundHasHiddenTopic_PosttestAction;
            this.ImplicitNext_NoOngoingRoundData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.OngoingRoundNotScoredData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.OnogingRoundIsNewestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ExplicitlyActivateRoundData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.ImplicitlyActivateRoundData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.NewRoundHasHiddenTopicData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            ImplicitNext_NoOngoingRound_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OngoingRoundNotScored_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OngoingRoundNotScored_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OngoingRoundNotScored_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OnogingRoundIsNewest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OnogingRoundIsNewest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            OnogingRoundIsNewest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ExplicitlyActivateRound_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ExplicitlyActivateRound_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ExplicitlyActivateRound_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ImplicitlyActivateRound_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            ImplicitlyActivateRound_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ImplicitlyActivateRound_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            NewRoundHasHiddenTopic_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            NewRoundHasHiddenTopic_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            NewRoundHasHiddenTopic_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // ImplicitNext_NoOngoingRound_TestAction
            // 
            ImplicitNext_NoOngoingRound_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(ImplicitNext_NoOngoingRound_TestAction, "ImplicitNext_NoOngoingRound_TestAction");
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 1;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "V danou chvíli neprobíhá žádné kolo, které lže použít jako referenci. Je nezbytné" +
                " specifikovat ID kola, která má být aktivováno!";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 1;
            scalarValueCondition1.RowNumber = 1;
            // 
            // OngoingRoundNotScored_TestAction
            // 
            OngoingRoundNotScored_TestAction.Conditions.Add(scalarValueCondition2);
            resources.ApplyResources(OngoingRoundNotScored_TestAction, "OngoingRoundNotScored_TestAction");
            // 
            // scalarValueCondition2
            // 
            scalarValueCondition2.ColumnNumber = 1;
            scalarValueCondition2.Enabled = true;
            scalarValueCondition2.ExpectedValue = "Právě probíhající kolo ještě nebylo vyhodnoceno! Není možné aktivovat nové kolo.";
            scalarValueCondition2.Name = "scalarValueCondition2";
            scalarValueCondition2.NullExpected = false;
            scalarValueCondition2.ResultSet = 1;
            scalarValueCondition2.RowNumber = 1;
            // 
            // OngoingRoundNotScored_PretestAction
            // 
            resources.ApplyResources(OngoingRoundNotScored_PretestAction, "OngoingRoundNotScored_PretestAction");
            // 
            // OngoingRoundNotScored_PosttestAction
            // 
            resources.ApplyResources(OngoingRoundNotScored_PosttestAction, "OngoingRoundNotScored_PosttestAction");
            // 
            // OnogingRoundIsNewest_TestAction
            // 
            OnogingRoundIsNewest_TestAction.Conditions.Add(scalarValueCondition3);
            resources.ApplyResources(OnogingRoundIsNewest_TestAction, "OnogingRoundIsNewest_TestAction");
            // 
            // scalarValueCondition3
            // 
            scalarValueCondition3.ColumnNumber = 1;
            scalarValueCondition3.Enabled = true;
            scalarValueCondition3.ExpectedValue = "Po právě probíhajícím kole nenásleduje žádné neaktivní kolo! Je potřeba založit n" +
                "ové kolo anebo specifikovat ID kola k aktivaci.";
            scalarValueCondition3.Name = "scalarValueCondition3";
            scalarValueCondition3.NullExpected = false;
            scalarValueCondition3.ResultSet = 1;
            scalarValueCondition3.RowNumber = 1;
            // 
            // OnogingRoundIsNewest_PretestAction
            // 
            resources.ApplyResources(OnogingRoundIsNewest_PretestAction, "OnogingRoundIsNewest_PretestAction");
            // 
            // OnogingRoundIsNewest_PosttestAction
            // 
            resources.ApplyResources(OnogingRoundIsNewest_PosttestAction, "OnogingRoundIsNewest_PosttestAction");
            // 
            // ExplicitlyActivateRound_TestAction
            // 
            ExplicitlyActivateRound_TestAction.Conditions.Add(scalarValueCondition4);
            resources.ApplyResources(ExplicitlyActivateRound_TestAction, "ExplicitlyActivateRound_TestAction");
            // 
            // scalarValueCondition4
            // 
            scalarValueCondition4.ColumnNumber = 1;
            scalarValueCondition4.Enabled = true;
            scalarValueCondition4.ExpectedValue = "1";
            scalarValueCondition4.Name = "scalarValueCondition4";
            scalarValueCondition4.NullExpected = false;
            scalarValueCondition4.ResultSet = 1;
            scalarValueCondition4.RowNumber = 1;
            // 
            // ExplicitlyActivateRound_PretestAction
            // 
            resources.ApplyResources(ExplicitlyActivateRound_PretestAction, "ExplicitlyActivateRound_PretestAction");
            // 
            // ExplicitlyActivateRound_PosttestAction
            // 
            resources.ApplyResources(ExplicitlyActivateRound_PosttestAction, "ExplicitlyActivateRound_PosttestAction");
            // 
            // ImplicitlyActivateRound_TestAction
            // 
            ImplicitlyActivateRound_TestAction.Conditions.Add(scalarValueCondition5);
            resources.ApplyResources(ImplicitlyActivateRound_TestAction, "ImplicitlyActivateRound_TestAction");
            // 
            // scalarValueCondition5
            // 
            scalarValueCondition5.ColumnNumber = 1;
            scalarValueCondition5.Enabled = true;
            scalarValueCondition5.ExpectedValue = "2";
            scalarValueCondition5.Name = "scalarValueCondition5";
            scalarValueCondition5.NullExpected = false;
            scalarValueCondition5.ResultSet = 1;
            scalarValueCondition5.RowNumber = 1;
            // 
            // ImplicitlyActivateRound_PretestAction
            // 
            resources.ApplyResources(ImplicitlyActivateRound_PretestAction, "ImplicitlyActivateRound_PretestAction");
            // 
            // ImplicitlyActivateRound_PosttestAction
            // 
            resources.ApplyResources(ImplicitlyActivateRound_PosttestAction, "ImplicitlyActivateRound_PosttestAction");
            // 
            // NewRoundHasHiddenTopic_TestAction
            // 
            NewRoundHasHiddenTopic_TestAction.Conditions.Add(scalarValueCondition6);
            resources.ApplyResources(NewRoundHasHiddenTopic_TestAction, "NewRoundHasHiddenTopic_TestAction");
            // 
            // scalarValueCondition6
            // 
            scalarValueCondition6.ColumnNumber = 1;
            scalarValueCondition6.Enabled = true;
            scalarValueCondition6.ExpectedValue = "false";
            scalarValueCondition6.Name = "scalarValueCondition6";
            scalarValueCondition6.NullExpected = false;
            scalarValueCondition6.ResultSet = 1;
            scalarValueCondition6.RowNumber = 1;
            // 
            // NewRoundHasHiddenTopic_PretestAction
            // 
            resources.ApplyResources(NewRoundHasHiddenTopic_PretestAction, "NewRoundHasHiddenTopic_PretestAction");
            // 
            // NewRoundHasHiddenTopic_PosttestAction
            // 
            resources.ApplyResources(NewRoundHasHiddenTopic_PosttestAction, "NewRoundHasHiddenTopic_PosttestAction");
            // 
            // ImplicitNext_NoOngoingRoundData
            // 
            this.ImplicitNext_NoOngoingRoundData.PosttestAction = null;
            this.ImplicitNext_NoOngoingRoundData.PretestAction = null;
            this.ImplicitNext_NoOngoingRoundData.TestAction = ImplicitNext_NoOngoingRound_TestAction;
            // 
            // OngoingRoundNotScoredData
            // 
            this.OngoingRoundNotScoredData.PosttestAction = OngoingRoundNotScored_PosttestAction;
            this.OngoingRoundNotScoredData.PretestAction = OngoingRoundNotScored_PretestAction;
            this.OngoingRoundNotScoredData.TestAction = OngoingRoundNotScored_TestAction;
            // 
            // OnogingRoundIsNewestData
            // 
            this.OnogingRoundIsNewestData.PosttestAction = OnogingRoundIsNewest_PosttestAction;
            this.OnogingRoundIsNewestData.PretestAction = OnogingRoundIsNewest_PretestAction;
            this.OnogingRoundIsNewestData.TestAction = OnogingRoundIsNewest_TestAction;
            // 
            // ExplicitlyActivateRoundData
            // 
            this.ExplicitlyActivateRoundData.PosttestAction = ExplicitlyActivateRound_PosttestAction;
            this.ExplicitlyActivateRoundData.PretestAction = ExplicitlyActivateRound_PretestAction;
            this.ExplicitlyActivateRoundData.TestAction = ExplicitlyActivateRound_TestAction;
            // 
            // ImplicitlyActivateRoundData
            // 
            this.ImplicitlyActivateRoundData.PosttestAction = ImplicitlyActivateRound_PosttestAction;
            this.ImplicitlyActivateRoundData.PretestAction = ImplicitlyActivateRound_PretestAction;
            this.ImplicitlyActivateRoundData.TestAction = ImplicitlyActivateRound_TestAction;
            // 
            // NewRoundHasHiddenTopicData
            // 
            this.NewRoundHasHiddenTopicData.PosttestAction = NewRoundHasHiddenTopic_PosttestAction;
            this.NewRoundHasHiddenTopicData.PretestAction = NewRoundHasHiddenTopic_PretestAction;
            this.NewRoundHasHiddenTopicData.TestAction = NewRoundHasHiddenTopic_TestAction;
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
        public void ImplicitNext_NoOngoingRound()
        {
            SqlDatabaseTestActions testActions = this.ImplicitNext_NoOngoingRoundData;
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
        public void OngoingRoundNotScored()
        {
            SqlDatabaseTestActions testActions = this.OngoingRoundNotScoredData;
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
        public void OnogingRoundIsNewest()
        {
            SqlDatabaseTestActions testActions = this.OnogingRoundIsNewestData;
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
        public void ExplicitlyActivateRound()
        {
            SqlDatabaseTestActions testActions = this.ExplicitlyActivateRoundData;
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
        public void ImplicitlyActivateRound()
        {
            SqlDatabaseTestActions testActions = this.ImplicitlyActivateRoundData;
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
        public void NewRoundHasHiddenTopic()
        {
            SqlDatabaseTestActions testActions = this.NewRoundHasHiddenTopicData;
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





        private SqlDatabaseTestActions ImplicitNext_NoOngoingRoundData;
        private SqlDatabaseTestActions OngoingRoundNotScoredData;
        private SqlDatabaseTestActions OnogingRoundIsNewestData;
        private SqlDatabaseTestActions ExplicitlyActivateRoundData;
        private SqlDatabaseTestActions ImplicitlyActivateRoundData;
        private SqlDatabaseTestActions NewRoundHasHiddenTopicData;
    }
}
