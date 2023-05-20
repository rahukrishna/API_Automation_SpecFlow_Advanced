using API_Automation_SpecFlow.Actions;
using API_Automation_SpecFlow.Models;
using API_Automation_SpecFlow.ResponseValidators;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;


namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding]
    public class PatchUsersAPiStepDefinitions
    {
        string? url;
        string? bodydata;
        UpdateUserRequest? JsonData;
        UpdatedUserResponse? patchedUserResponse;        
        [Given(@"Want to patch user details")]
        public void GivenWantToPatchUserDetails()
        {
            url = Helpers.Helpers.getBaseURL();            
        }

        [When(@"the name (.+) and (.+) is provided")]
        public void WhenTheNameRahulKAndNewJobIsProvided(string name, string newJob)
        {
            bodydata = Helpers.BodyData.updateRequestData(name, newJob);
            JsonData = JsonConvert.DeserializeObject<UpdateUserRequest>(bodydata);            
        }

        [When(@"trying to get the data")]
        public void WhenTryingToGetTheData()
        {
            patchedUserResponse = Serivce_Actions.Update_User(JsonData, url);            
        }

        [Then(@"the patched response should contain the name (.+) and new job (.+)")]
        public void ThenThePatchedResponseShouldContainTheNameAndNewJob(string name, string newJob)
        {
            Assert.IsTrue(ResponseValidations.patchUserResponseValidations(patchedUserResponse, name, newJob));           
        }
    }
}
