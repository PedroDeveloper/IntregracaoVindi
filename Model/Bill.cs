using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegracaoVindi.API.Model;


namespace IntegracaoVindi.API.Model
{
    public class Bill
    {
        public int? id { get; set; }
        public string code { get; set; }
        public string amount { get; set; }
        public int? installments { get; set; }
        public string status { get; set; }
        public DateTime?seen_at { get; set; }
        public string billing_at { get; set; }
        public DateTime?due_at { get; set; }
        public string url { get; set; }
        public DateTime?created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public List<BillItem> bill_items { get; set; }
        public List<Charge> charges { get; set; }
        public Customer customer { get; set; }
        public Period period { get; set; }
        public Subscription subscription { get; set; }
        public Metadata metadata { get; set; }
        public PaymentProfile PaymentProfile { get; set; }
        public PaymentCondition? payment_condition { get; set; }
    }

        public class BillHolder
        {
            public List<Bill> bills { get; set; }
        }
        public class PaymentCondition
        {
            public int? penalty_fee_value { get; set; }
            public string penalty_fee_type { get; set; }
            public int? daily_fee_value { get; set; }
            public string daily_fee_type { get; set; }
            public int? after_due_days { get; set; }
            public List<PaymentConditionDiscount> payment_condition_discounts { get; set; }
        }
        public class PaymentConditionDiscount
        {
            public int? value { get; set; }
            public int? value_type { get; set; }
            public int? days_before_due { get; set; }
        }

        public class PricingSchema
        {

            public int? id { get; set; }
            public string short_format { get; set; }
            public string price { get; set; }
            public string minimum_price { get; set; }
            public string schema_type { get; set; }
            public List<object> pricing_ranges { get; set; }
            public DateTime? created_at { get; set; }
        }

        public class Product
        {
            public int? id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class ProductItem
        {
            public int? id { get; set; }
            public Product product { get; set; }
        }

        public class BillItem
        {
            public int? id { get; set; }
            public string amount { get; set; }
            public int? quantity { get; set; }
            public object pricing_range_id { get; set; }
            public object description { get; set; }
            public PricingSchema pricing_schema { get; set; }
            public Product product { get; set; }
            public ProductItem product_item { get; set; }
            public object discount { get; set; }
        }

        public class GatewayResponseFields
        {
            public string nsu { get; set; }
        }

        public class Gateway
        {
            public int? id { get; set; }
            public string connector { get; set; }
        }

        public class PaymentCompany
        {
            public int? id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }


        public class LastTransaction
        {
            public int? id { get; set; }
            public string transaction_type { get; set; }
            public string status { get; set; }
            public string amount { get; set; }
            public int? installments { get; set; }
            public string gateway_message { get; set; }
            public string gateway_response_code { get; set; }
            public string gateway_authorization { get; set; }
            public string gateway_transaction_id { get; set; }
            public GatewayResponseFields gateway_response_fields { get; set; }
            public object fraud_detector_score { get; set; }
            public object fraud_detector_status { get; set; }
            public object fraud_detector_id { get; set; }
            public DateTime? created_at { get; set; }
            public Gateway gateway { get; set; }
            public PaymentProfile paymentProfile { get; set; }
        }

        public class PaymentMethod
        {
            public int? id { get; set; }
            public string public_name { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string type { get; set; }
        }

        public class Charge
        {
            public int? id { get; set; }
            public string amount { get; set; }
            public string status { get; set; }
            public DateTime? due_at { get; set; }
            public object paid_at { get; set; }
            public int? installments { get; set; }
            public int? attempt_count { get; set; }
            public DateTime? next_attempt { get; set; }
            public object print_url { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
            public LastTransaction last_transaction { get; set; }
            public PaymentMethod payment_method { get; set; }
        }


        public class Period
        {
            public int? id { get; set; }
            public DateTime? billing_at { get; set; }
            public int? cycle { get; set; }
            public DateTime? start_at { get; set; }
            public DateTime? end_at { get; set; }
            public int? duration { get; set; }
        }

        public class Plan
        {
            public int? id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Subscription
        {
            public int? id { get; set; }
            public string code { get; set; }
            public Plan plan { get; set; }
            public Customer customer { get; set; }
        }

        public class Metadata
        {
        }


    }


