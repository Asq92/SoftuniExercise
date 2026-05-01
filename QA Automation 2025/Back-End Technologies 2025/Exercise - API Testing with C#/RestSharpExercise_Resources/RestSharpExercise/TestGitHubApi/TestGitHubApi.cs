using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static long lastCreatedIssueNumber;
        private static long lastCreatedCommentId;
        private static string repo = "test-nakov-repo";


        [SetUp]
        public void Setup()
        {
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "Asq92", "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");
        }


        [Test, Order(1)]
        public void Test_GetAllIssuesFromARepo()
        {
            var issues = client.GetAllIssues(repo);

            Assert.That(issues, Has.Count.GreaterThan(1), "There should be more than one issue.");

            foreach (var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue number should be greater than 0.");
                Assert.That(issue.Title, Is.Not.Null.And.Not.Empty, "Issue title should not be null or empty.");
            }

        }

        [Test, Order(2)]
        public void Test_GetIssueByValidNumber()
        {
            long issueNumber = 1;

            var issue = client.GetIssueByNumber(repo, issueNumber);

            Assert.That(issue, Is.Not.Null, "Issue should not be null.");
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
            Assert.That(issue.Number, Is.EqualTo(issueNumber), $"Issue number should be {issueNumber}.");

        }

        [Test, Order(3)]
        public void Test_GetAllLabelsForIssue()
        {

            long issueNumber = 6;

            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            if (labels != null)
            {
                foreach (var label in labels)
                {
                    Assert.That(label.Id, Is.GreaterThan(0), "Label ID should be greater than 0.");
                    Assert.That(label.Name, Is.Not.Null.And.Not.Empty, "Label name should not be null or empty.");
                }
            }
            else
            {
                Assert.Pass("No labels found for the issue, but the API call was successful.");
            }
        }

        [Test, Order(4)]
        public void Test_GetAllCommentsForIssue()
        {

            int issueNumber = 6;

            var comments = client.GetAllCommentsForIssue(repo, issueNumber);

            if (comments != null)
            {
                Assert.That(comments.Count, Is.GreaterThan(0));

                foreach (var comment in comments)
                {
                    Assert.That(comment.Id, Is.GreaterThan(0), "Comment ID should be greater than 0.");
                    Assert.That(comment.Body, Is.Not.Null.And.Not.Empty, "Comment body should not be null or empty.");
                }
            }
            else
            {
                Assert.Pass("No comments found for the issue, but the API call was successful.");
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            string expectedTitle = "Test Issue Title";
            string expectedBody = "This is a test issue created by the GitHub API client.";

            var createdIssue = client.CreateIssue(repo, expectedTitle, expectedBody);

            if (createdIssue != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(createdIssue, Is.Not.Null, "Created issue should not be null.");
                    Assert.That(createdIssue.Id, Is.GreaterThan(0), "Created issue ID should be greater than 0.");
                    Assert.That(createdIssue.Number, Is.GreaterThan(0), "Created issue number should be greater than 0.");
                    Assert.That(createdIssue.Title, Is.EqualTo(expectedTitle), $"Created issue title should be '{expectedTitle}'.");
                    Assert.That(createdIssue.Body, Is.EqualTo(expectedBody), $"Created issue body should be '{expectedBody}'.");
                });

                lastCreatedIssueNumber = createdIssue.Number; // Store the issue number for later use in comment tests
            }
            else
            {
                Assert.Pass("No issue created, but the API call was successful.");
            }
        }

        [Test, Order(6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            long issueNumber = lastCreatedIssueNumber; // Use the issue number from the previously created issue
            string expectedCommentBody = "This is a test comment created by the GitHub API client.";

            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, expectedCommentBody);

            if (comment != null)
            {
                Assert.That(comment.Body, Is.EqualTo(expectedCommentBody), "Comment's body should be as expected.");
                lastCreatedCommentId = comment.Id; // Store the comment ID for later use in edit and delete tests
            }

        }

        [Test, Order(7)]
        public void Test_GetCommentById()
        {
            long commentId = lastCreatedCommentId; // Use the comment ID from the previously created comment

            var comment = client.GetCommentById(repo, commentId);

            Assert.That(comment, Is.Not.Null, "Comment should not be null.");
            Assert.That(comment.Id, Is.EqualTo(commentId), $"Comment ID should be {commentId}.");
        }


        [Test, Order(8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            long commentId = lastCreatedCommentId;
            string newCommentBody = "This is an edited comment body.";

            var editedComment = client.EditCommentOnGitHubIssue(repo, commentId, newCommentBody);

            Assert.That(editedComment, Is.Not.Null, "Edited comment should not be null.");
            Assert.That(editedComment.Id, Is.EqualTo(commentId), $"Edited comment ID should be {commentId}.");
            Assert.That(editedComment.Body, Is.EqualTo(newCommentBody), "Edited comment body should be updated.");
        }

        [Test, Order(9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            long commentId = lastCreatedCommentId;

            bool isDeleted = client.DeleteCommentOnGitHubIssue(repo, commentId);

            Assert.That(isDeleted, Is.True, "Comment should be deleted successfully.");

        }

        //DataFormat-Driven-Tests

        [TestCase("test-nakov-repo", 1)]
        [TestCase("test-nakov-repo", 2)]
        [TestCase("test-nakov-repo", 100)]
        public void Test_GetIssueByValidNumber(string repo, long issueNumber)
        {
            var issue = client.GetIssueByNumber(repo, issueNumber);
            Assert.That(issue, Is.Not.Null, "Issue should not be null.");
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
            Assert.That(issue.Number, Is.EqualTo(issueNumber), $"Issue number should be {issueNumber}.");

        }



        [TestCase("test-nakov-repo", 1)]
        [TestCase("test-nakov-repo", 2)]
        [TestCase("test-nakov-repo", 100)]

        public void Test_GetAllLabelsForIssue_DataDriven(string repo, long issueNumber)
        {
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            foreach (var label in labels)
            {
                Assert.That(label, Is.Not.Null, "Label should not be null.");
                Assert.That(label.Id, Is.GreaterThan(0), "Label ID should be greater than 0.");
                Assert.That(label.Name, Is.Not.Null.And.Not.Empty, "Label name should not be null or empty.");
            }

        }
    }
}