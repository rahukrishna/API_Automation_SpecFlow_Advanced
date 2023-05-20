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
    public class UpdateUsersAPiValidationsStepDefinitions
    {
        string? url;
        string? bodydata;
        UpdateUserRequest? JsonData;
        UpdatedUserResponse? updatedUserResponse;        
        [Given(@"Want to update the user details")]
        public void GivenWantToUpdateTheUserDetails()
        {
            url = Helpers.Helpers.getBaseURL();

        }

        [When(@"Passing the name (.+) and new Job (.+)")]
        public void WhenPassingTheNameAndNewJob(string name, string newJob)
        {
            bodydata = Helpers.BodyData.createRequestData(name, newJob);
            JsonData = JsonConvert.DeserializeObject<UpdateUserRequest>(bodydata);         
        }

        [When(@"retrying the update data")]
        public void WhenRetryingTheUpdateData()
        {            
            updatedUserResponse = Serivce_Actions.Update_User(JsonData, url);
        }

        [Then(@"I should get the response of updated response with name (.+) and new job (.+)")]
        public void ThenIShouldGetTheResponseOfUpdatedResponseWithNameAndNewJob(string name, string newJob)
        {
            Assert.IsTrue(ResponseValidations.updateUserResponseValidations(updatedUserResponse, name, newJob));           

        }
    }
}
