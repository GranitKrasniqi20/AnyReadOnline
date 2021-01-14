
using AnyReadOnline.BOL;
using AnyReadOnline.BOL.Interfaces;
using RateWebServiceClient.RateServiceWebReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ApplicationServices;

namespace AnyReadOnline.BLL
{
    public class FedExRates
    {
        public static void addmore(Order order)
        {
            RateRequest request = CreateRateRequest(order);
            //
            RateService service = new RateService();
            if (usePropertyFile())
            {
                service.Url = getProperty("https://wsbeta.fedex.com/web-services/rate");
            }
            try
            {
                // Call the web service passing in a RateRequest and returning a RateReply
                RateWebServiceClient.RateServiceWebReference.RateReply reply = service.getRates(request);

                if (reply.HighestSeverity == NotificationSeverityType.SUCCESS || reply.HighestSeverity == NotificationSeverityType.NOTE || reply.HighestSeverity == RateWebServiceClient.RateServiceWebReference.NotificationSeverityType.WARNING)
                {
                    //ShowRateReply(reply);
                }
                //ShowNotifications(reply);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press any key to quit!");
            Console.ReadKey();
        }

        private static RateRequest CreateRateRequest(Order order)
        {
            // Build a RateRequest
            RateRequest request = new RateRequest();
            //
            request.WebAuthenticationDetail = new WebAuthenticationDetail();
            request.WebAuthenticationDetail.UserCredential = new WebAuthenticationCredential();
            request.WebAuthenticationDetail.UserCredential.Key = "s3lfZ6PldQHNadXn";
            request.WebAuthenticationDetail.UserCredential.Password = "qfHLki6gFPYPZ8Befs3OM801J"; 
            request.WebAuthenticationDetail.ParentCredential = new WebAuthenticationCredential();
            request.WebAuthenticationDetail.ParentCredential.Key = "XXX"; 
            request.WebAuthenticationDetail.ParentCredential.Password = "XXX"; 

            request.ClientDetail = new ClientDetail();
            request.ClientDetail.AccountNumber = "510087720"; 
            request.ClientDetail.MeterNumber = "119190657"; 

            request.TransactionDetail = new TransactionDetail();
            request.TransactionDetail.CustomerTransactionId = "***Rate Request using VC#***"; 
            //
            request.Version = new VersionId();
            //
            request.ReturnTransitAndCommit = true;
            request.ReturnTransitAndCommitSpecified = true;
            //
            SetShipmentDetails(request, order);
            //
            return request;
        }

        private static void SetShipmentDetails(RateRequest request, Order order)
        {
            request.RequestedShipment = new RequestedShipment();
            request.RequestedShipment.ShipTimestamp = DateTime.Now;
            request.RequestedShipment.ShipTimestampSpecified = true;
            request.RequestedShipment.DropoffType = DropoffType.REGULAR_PICKUP; 
            request.RequestedShipment.ServiceType = "INTERNATIONAL_PRIORITY"; // Service types are STANDARD_OVERNIGHT, PRIORITY_OVERNIGHT, FEDEX_GROUND ...
                                                                              // request.RequestedShipment.ServiceTypeSpecified = true;
            request.RequestedShipment.PackagingType = "YOUR_PACKAGING"; // Packaging type FEDEX_BOK, FEDEX_PAK, FEDEX_TUBE, YOUR_PACKAGING, ...
                                                                        // request.RequestedShipment.PackagingTypeSpecified = true;
                                                                        //
            SetOrigin(request);
            //
            SetDestination(request, order.ShippingAddress);
            //
            SetPackageLineItems(request, order.OrderDetails);
            //
            request.RequestedShipment.TotalInsuredValue = new Money();
            request.RequestedShipment.TotalInsuredValue.Amount = 100;
            request.RequestedShipment.TotalInsuredValue.Currency = "EUR";
            //
            request.RequestedShipment.PackageCount = "2";
        }

        private static void SetOrigin(RateRequest request)
        {

            //request.RequestedShipment.Shipper = new Party();
            //request.RequestedShipment.Shipper.Address = new RateWebServiceClient.RateServiceWebReference.Address();
            //request.RequestedShipment.Shipper.Address.StreetLines = new string[1] { "Pallati 37 shkalla 4 apartamenti 15" };
            //request.RequestedShipment.Shipper.Address.City = "Tirana";
            ////request.RequestedShipment.Recipient.Address.StateOrProvinceCode = "TR";
            //request.RequestedShipment.Shipper.Address.PostalCode = "1001";
            //request.RequestedShipment.Shipper.Address.CountryCode = "AL";



            request.RequestedShipment.Shipper = new Party();
            request.RequestedShipment.Shipper.Address = new RateWebServiceClient.RateServiceWebReference.Address();
            request.RequestedShipment.Shipper.Address.StreetLines = new string[1] { "Rudolstaedter Strasse 85" };
            request.RequestedShipment.Shipper.Address.City = "Haibach";
            request.RequestedShipment.Shipper.Address.StateOrProvinceCode = "BY";
            request.RequestedShipment.Shipper.Address.PostalCode = "63802";
            request.RequestedShipment.Shipper.Address.CountryCode = "DE";


        }

        private static void SetDestination(RateRequest request, BOL.Address address)
        {
            request.RequestedShipment.Recipient = new Party();
            request.RequestedShipment.Recipient.Address = new RateWebServiceClient.RateServiceWebReference.Address();
            request.RequestedShipment.Recipient.Address.StreetLines = new string[1] { $"{address.Address1}" };
            request.RequestedShipment.Recipient.Address.City = $"{address.City}";
            request.RequestedShipment.Recipient.Address.PostalCode = $"{address.PostalCode}";
            request.RequestedShipment.Recipient.Address.CountryCode = $"{address.Country.CountryCode}";
        }

        private static void SetPackageLineItems(RateRequest request, List<OrderDetails> orderDetails)
        {
            request.RequestedShipment.RequestedPackageLineItems = new RequestedPackageLineItem[orderDetails.Count];
            for (int i = 0; i < orderDetails.Count; i++)
            {
                request.RequestedShipment.RequestedPackageLineItems[i] = new RequestedPackageLineItem();
                request.RequestedShipment.RequestedPackageLineItems[i].SequenceNumber = $"{i+1}"; // package sequence number
                request.RequestedShipment.RequestedPackageLineItems[i].GroupPackageCount = "1";
                // package weight
                request.RequestedShipment.RequestedPackageLineItems[i].Weight = new Weight();
                request.RequestedShipment.RequestedPackageLineItems[i].Weight.Units = WeightUnits.KG;
                request.RequestedShipment.RequestedPackageLineItems[i].Weight.UnitsSpecified = true;
                request.RequestedShipment.RequestedPackageLineItems[i].Weight.Value = orderDetails[0].Book.Weight;
                request.RequestedShipment.RequestedPackageLineItems[i].Weight.ValueSpecified = true;
                // package dimensions
                request.RequestedShipment.RequestedPackageLineItems[i].Dimensions = new Dimensions();
                request.RequestedShipment.RequestedPackageLineItems[i].Dimensions.Length = $"{Math.Floor(orderDetails[0].Book.Length)}";
                request.RequestedShipment.RequestedPackageLineItems[i].Dimensions.Width = $"{Math.Floor(orderDetails[0].Book.Width)}";
                request.RequestedShipment.RequestedPackageLineItems[i].Dimensions.Height = $"{Math.Floor(orderDetails[0].Book.Height)}";
                request.RequestedShipment.RequestedPackageLineItems[i].Dimensions.Units = LinearUnits.CM;
                request.RequestedShipment.RequestedPackageLineItems[i].Dimensions.UnitsSpecified = true;
                // insured value
                request.RequestedShipment.RequestedPackageLineItems[i].InsuredValue = new Money();
                request.RequestedShipment.RequestedPackageLineItems[i].InsuredValue.Amount = 100;
                request.RequestedShipment.RequestedPackageLineItems[i].InsuredValue.Currency = "EUR";
            }
            //





        }

       
        private static bool usePropertyFile() //Set to true for common properties to be set with getProperty function.
        {
            return getProperty("usefile").Equals("True");
        }
        private static String getProperty(String propertyname) //Sets common properties for testing purposes.
        {
            try
            {
                String filename = "D:\\CS_WSGW_Properties.txt";
                if (System.IO.File.Exists(filename))
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(filename);
                    do
                    {
                        String[] parts = sr.ReadLine().Split(',');
                        if (parts[0].Equals(propertyname) && parts.Length == 2)
                        {
                            return parts[1];
                        }
                    }
                    while (!sr.EndOfStream);
                }
                Console.WriteLine("Property {0} set to default 'XXX'", propertyname);
                return "XXX";
            }
            catch (Exception e)
            {
                Console.WriteLine("Property {0} set to default 'XXX'", propertyname);
                return "XXX";
            }
        }
    }
}
