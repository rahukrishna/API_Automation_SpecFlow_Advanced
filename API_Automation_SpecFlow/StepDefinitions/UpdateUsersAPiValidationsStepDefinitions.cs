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
        string? bodydata ;
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
            bodydata = Helpers.BodyData.updateRequestData(name, newJob);
            JsonData = JsonConvert.DeserializeObject<UpdateUserRequest>(bodydata);         
        }

        [When(@"retrying the update data")]
        public void WhenRetryingTheUpdateData()
        {            
            if (JsonData != null && url != null)
            updatedUserResponse = Serivce_Actions.Update_User(JsonData, url);
        }

        [Then(@"I should get the response of updated response with name (.+) and new job (.+)")]
        public void ThenIShouldGetTheResponseOfUpdatedResponseWithNameAndNewJob(string name, string newJob)
        {
            if(updatedUserResponse!= null)
            Assert.IsTrue(ResponseValidations.updateUserResponseValidations(updatedUserResponse, name, newJob));           

        }
    }
}
