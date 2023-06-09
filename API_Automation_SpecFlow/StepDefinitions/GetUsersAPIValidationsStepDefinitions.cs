using RestSharp;
using NUnit.Framework;
using API_Automation_SpecFlow.Models;
using Newtonsoft.Json;
using API_Automation_SpecFlow.Actions;
using API_Automation_SpecFlow.ResponseValidators;
using System.Xml.Linq;

namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding]
    public class GetUsersAPIValidationsStepDefinitions
    {
        string? url ;        
        ListUserResponse? usersListResponse = new();
        SingleUserResponse? singleUserResponse;        


        [Given(@"Want to know the users list")]
        public void GivenWantToKnowTheUsersList()
        {
            url = Helpers.Helpers.getBaseURL();
        }

        [When(@"I retrive the data of users list")]
        public void WhenIRetriveTheDataOfUsersList()
        {
            if (url != null) 
            usersListResponse = Serivce_Actions.get_ListUser(url);            
        }

        [Then(@"Users list should contain some value")]
        public void ThenUsersListShouldContainSomeValue()
        {
            if (usersListResponse != null)
                Assert.IsTrue(ResponseValidations.listUserResponseValidations(usersListResponse));

        }
        [Given(@"Iwant to get single user details")]
        public void GivenIwantToGetSingleUserDetails()
        {
            url = Helpers.Helpers.getBaseURL();            
        }

        [When(@"I retrivee data for a single user")]
        public void WhenIRetriveeDataForASingleUser()
        {
            if (url!= null)
            singleUserResponse = Serivce_Actions.get_SingleUser(url);            
        }

        [Then(@"I should get the details of singke user")]
        public void ThenIShouldGetTheDetailsOfSingkeUser()
        {
            if(singleUserResponse != null)
            Assert.IsTrue(ResponseValidations.singleUserResponseValidations(singleUserResponse));           

        }


    }
}
