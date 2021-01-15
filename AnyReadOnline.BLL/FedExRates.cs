
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
        public  BOL.FedExRates.RateReplyDetails GetRate(Order order)
        {
            RateRequest request = CreateRateRequest(order);
            //
            RateService service = new RateService();
            //if (usePropertyFile())
            //{
            //    service.Url = getProperty("https://wsbeta.fedex.com/web-services/rate");
            //}
            try
            {
                // Call the web service passing in a RateRequest and returning a RateReply
                RateWebServiceClient.RateServiceWebReference.RateReply reply = service.getRates(request);

                if (reply.HighestSeverity == NotificationSeverityType.SUCCESS || reply.HighestSeverity == NotificationSeverityType.NOTE || reply.HighestSeverity == RateWebServiceClient.RateServiceWebReference.NotificationSeverityType.WARNING)
                {
                    GetRateReply(reply);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        private  RateRequest CreateRateRequest(Order order)
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

        private  void SetShipmentDetails(RateRequest request, Order order)
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

        private void SetOrigin(RateRequest request)
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

        private void SetDestination(RateRequest request, BOL.Address address)
        {
            request.RequestedShipment.Recipient = new Party();
            request.RequestedShipment.Recipient.Address = new RateWebServiceClient.RateServiceWebReference.Address();
            request.RequestedShipment.Recipient.Address.StreetLines = new string[1] { $"{address.Address1}" };
            request.RequestedShipment.Recipient.Address.City = $"{address.City}";
            request.RequestedShipment.Recipient.Address.PostalCode = $"{address.PostalCode}";
            request.RequestedShipment.Recipient.Address.CountryCode = $"{address.Country.CountryCode}";
        }

        private void SetPackageLineItems(RateRequest request, List<OrderDetails> orderDetails)
        {
            request.RequestedShipment.RequestedPackageLineItems = new RequestedPackageLineItem[orderDetails.Count];
            for (int i = 0; i < orderDetails.Count; i++)
            {
                request.RequestedShipment.RequestedPackageLineItems[i] = new RequestedPackageLineItem();
                request.RequestedShipment.RequestedPackageLineItems[i].SequenceNumber = $"{i + 1}"; // package sequence number
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


        private BOL.FedExRates.RateReplyDetails GetRateReply(RateReply reply)
        {

            BOL.FedExRates.RateReplyDetails ratedShipmentDetails = new BOL.FedExRates.RateReplyDetails();



            foreach (RateReplyDetail rateReplyDetail in reply.RateReplyDetails)
            {
                ratedShipmentDetails.RateReplies.Add(FormatRateReplyDetail(rateReplyDetail));
                ratedShipmentDetails.DeliveryTimestamp = rateReplyDetail.DeliveryTimestamp;
                ratedShipmentDetails.TransitTime = ratedShipmentDetails.TransitTime;
                // if (rateReplyDetail.ServiceTypeSpecified)

                // if (rateReplyDetail.PackagingTypeSpecified)


            }

            return ratedShipmentDetails;
        }



        private  BOL.FedExRates.RateReply FormatRateReplyDetail(RateReplyDetail rateReplyDetail)
        {
            BOL.FedExRates.RateReply rateReply = new BOL.FedExRates.RateReply();


            rateReply.ServiceType = rateReplyDetail.ServiceType;
            rateReply.PackagingType = rateReplyDetail.PackagingType;
            rateReply.RatedShipmentDetails = new List<BOL.FedExRates.RatedShipmentDetails>();
            foreach (var item in rateReplyDetail.RatedShipmentDetails)
            {
                rateReply.RatedShipmentDetails.Add(ShowShipmentRateDetails(item));
            }
            return rateReply;


        }








        private BOL.FedExRates.RatedShipmentDetails ShowShipmentRateDetails(RatedShipmentDetail shipmentDetail)
        {
            if (shipmentDetail == null) return null;
            if (shipmentDetail.ShipmentRateDetail == null) return null;
            ShipmentRateDetail rateDetail = shipmentDetail.ShipmentRateDetail;
            //
            BOL.FedExRates.RatedShipmentDetails FormatDetail = new BOL.FedExRates.RatedShipmentDetails();


            FormatDetail.RateType = rateDetail.RateType.ToString();


            FormatDetail.TotalBillingAmount = (double)rateDetail.TotalBillingWeight.Value;
            FormatDetail.Currency = shipmentDetail.ShipmentRateDetail.TotalBillingWeight.Units.ToString();

            FormatDetail.TotalBaseChargeAmount = (double)rateDetail.TotalBaseCharge.Amount;
            FormatDetail.TotalFreightDiscountsAmount = (double)rateDetail.TotalFreightDiscounts.Amount;
            FormatDetail.TotalSurchargesAmount = (double)rateDetail.TotalSurcharges.Amount;
            FormatDetail.surcharges = new List<BOL.FedExRates.Surcharges>();
            if (rateDetail.Surcharges != null)
            {
                foreach (Surcharge surcharge in rateDetail.Surcharges)
                    FormatDetail.surcharges.Add(new BOL.FedExRates.Surcharges() { SurchargeAmount = (double)surcharge.Amount.Amount, SurchargeCurrency = surcharge.Amount.Currency, SurchargeType = surcharge.SurchargeType.ToString() });


            }
            FormatDetail.TotalNetCharge = (double)rateDetail.TotalNetCharge.Amount;

            return FormatDetail;
        }







     
    }

}
