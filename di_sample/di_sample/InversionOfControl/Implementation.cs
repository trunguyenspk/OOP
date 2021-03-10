using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace di_sample.InversionOfControl
{
    public class Implementation
    {

    }

    #region Without Using Inversion Of Control
    //CustomerBusinessLogic and DataAccess classes are tightly coupled classes.So, changes in the DataAccess class will lead to changes in the CustomerBusinessLogic class. 
    //For example, if we add, remove or rename any method in the DataAccess class then we need to change the CustomerBusinessLogic class accordingly.

    //Suppose the customer data comes from different databases or web services and, in the future, we may need to create different classes,
    //so this will lead to changes in the CustomerBusinessLogic class.

    //The CustomerBusinessLogic class creates an object of the DataAccess class using the new keyword.There may be multiple classes which use the DataAccess class and create its objects.
    //So, if you change the name of the class, then you need to find all the places in your source code where you created objects of DataAccess and make the changes throughout the code.
    //This is repetitive code for creating objects of the same class and maintaining their dependencies.

    //Because the CustomerBusinessLogic class creates an object of the concrete DataAccess class, it cannot be tested independently(TDD). The DataAccess class cannot be replaced with a mock class

    /*public class CustomerBusinessLogic
    {
        DataAccess _dataAccess;

        public CustomerBusinessLogic()
        {
            _dataAccess = new DataAccess();
        }

        public string GetCustomerName(int id)
        {
            return _dataAccess.GetCustomerName(id);
        }
    }

    public class DataAccess
    {
        public DataAccess()
        {
        }

        public string GetCustomerName(int id)
        {
            return "Dummy Customer Name"; // get it from DB in real app
        }
    }*/

    #endregion

    //Use IoC - DIP
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }

    public class CustomerDataAccess : ICustomerDataAccess
    {
        public CustomerDataAccess()
        {

        }
        public string GetCustomerName(int id)
        {
            return "Customer Name";
        }
    }

    public class DataAccessFactory
    {
        public static ICustomerDataAccess GetCustomerDataAccessObj()
        {
            return new CustomerDataAccess();
        }
    }

    public class CustomerBusinessLogic
    {
        ICustomerDataAccess _custDataAccess;

        public CustomerBusinessLogic()
        {
            _custDataAccess = DataAccessFactory.GetCustomerDataAccessObj();
        }

        public string GetCustomerName(int id)
        {
            return _custDataAccess.GetCustomerName(id);
        }
    }

    public class CustomerBusinessLogic_ConstructorInjection
    {
        ICustomerDataAccess _custDataAccess;

        public CustomerBusinessLogic_ConstructorInjection(ICustomerDataAccess custDataAccess)
        {
            _custDataAccess = custDataAccess;
        }

        public string GetCustomerName(int id)
        {
            return _custDataAccess.GetCustomerName(id);
        }
    }

    public class CustomerService
    {
        CustomerBusinessLogic_ConstructorInjection _customerBL;

        public CustomerService()
        {
            _customerBL = new CustomerBusinessLogic_ConstructorInjection(new CustomerDataAccess());
        }

        public string GetCustomerName(int id)
        {
            return _customerBL.GetCustomerName(id);
        }
    }
}
