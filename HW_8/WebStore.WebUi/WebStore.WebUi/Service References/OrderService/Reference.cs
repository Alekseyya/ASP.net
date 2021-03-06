﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebStore.WebUi.OrderService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDataContract", Namespace="http://schemas.datacontract.org/2004/07/WebStore.Domain.DataContracts.Service")]
    [System.SerializableAttribute()]
    public partial class OrderDataContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IdField;
        
        private System.DateTime OrderDateField;
        
        private decimal OrderPriceField;
        
        private string UserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime OrderDate {
            get {
                return this.OrderDateField;
            }
            set {
                if ((this.OrderDateField.Equals(value) != true)) {
                    this.OrderDateField = value;
                    this.RaisePropertyChanged("OrderDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal OrderPrice {
            get {
                return this.OrderPriceField;
            }
            set {
                if ((this.OrderPriceField.Equals(value) != true)) {
                    this.OrderPriceField = value;
                    this.RaisePropertyChanged("OrderPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDetailsDataContract", Namespace="http://schemas.datacontract.org/2004/07/WebStore.Domain.DataContracts.Service")]
    [System.SerializableAttribute()]
    public partial class OrderDetailsDataContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IdField;
        
        private int OrderIdField;
        
        private string ProductField;
        
        private int QuantityField;
        
        private decimal TotalPriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int OrderId {
            get {
                return this.OrderIdField;
            }
            set {
                if ((this.OrderIdField.Equals(value) != true)) {
                    this.OrderIdField = value;
                    this.RaisePropertyChanged("OrderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Product {
            get {
                return this.ProductField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductField, value) != true)) {
                    this.ProductField = value;
                    this.RaisePropertyChanged("Product");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal TotalPrice {
            get {
                return this.TotalPriceField;
            }
            set {
                if ((this.TotalPriceField.Equals(value) != true)) {
                    this.TotalPriceField = value;
                    this.RaisePropertyChanged("TotalPrice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderService.IOrderService")]
    public interface IOrderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/AddOrder", ReplyAction="http://tempuri.org/IOrderService/AddOrderResponse")]
        void AddOrder(WebStore.WebUi.OrderService.OrderDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/AddOrder", ReplyAction="http://tempuri.org/IOrderService/AddOrderResponse")]
        System.Threading.Tasks.Task AddOrderAsync(WebStore.WebUi.OrderService.OrderDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrders", ReplyAction="http://tempuri.org/IOrderService/GetOrdersResponse")]
        WebStore.WebUi.OrderService.OrderDataContract[] GetOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrders", ReplyAction="http://tempuri.org/IOrderService/GetOrdersResponse")]
        System.Threading.Tasks.Task<WebStore.WebUi.OrderService.OrderDataContract[]> GetOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrderById", ReplyAction="http://tempuri.org/IOrderService/GetOrderByIdResponse")]
        WebStore.WebUi.OrderService.OrderDataContract GetOrderById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrderById", ReplyAction="http://tempuri.org/IOrderService/GetOrderByIdResponse")]
        System.Threading.Tasks.Task<WebStore.WebUi.OrderService.OrderDataContract> GetOrderByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/UpdateOrder", ReplyAction="http://tempuri.org/IOrderService/UpdateOrderResponse")]
        void UpdateOrder(WebStore.WebUi.OrderService.OrderDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/UpdateOrder", ReplyAction="http://tempuri.org/IOrderService/UpdateOrderResponse")]
        System.Threading.Tasks.Task UpdateOrderAsync(WebStore.WebUi.OrderService.OrderDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/DeleteOrder", ReplyAction="http://tempuri.org/IOrderService/DeleteOrderResponse")]
        void DeleteOrder(WebStore.WebUi.OrderService.OrderDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/DeleteOrder", ReplyAction="http://tempuri.org/IOrderService/DeleteOrderResponse")]
        System.Threading.Tasks.Task DeleteOrderAsync(WebStore.WebUi.OrderService.OrderDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/AddOrderDetails", ReplyAction="http://tempuri.org/IOrderService/AddOrderDetailsResponse")]
        void AddOrderDetails(WebStore.WebUi.OrderService.OrderDetailsDataContract[] order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/AddOrderDetails", ReplyAction="http://tempuri.org/IOrderService/AddOrderDetailsResponse")]
        System.Threading.Tasks.Task AddOrderDetailsAsync(WebStore.WebUi.OrderService.OrderDetailsDataContract[] order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrderDetails", ReplyAction="http://tempuri.org/IOrderService/GetOrderDetailsResponse")]
        WebStore.WebUi.OrderService.OrderDetailsDataContract[] GetOrderDetails();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrderDetails", ReplyAction="http://tempuri.org/IOrderService/GetOrderDetailsResponse")]
        System.Threading.Tasks.Task<WebStore.WebUi.OrderService.OrderDetailsDataContract[]> GetOrderDetailsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrderDetailsById", ReplyAction="http://tempuri.org/IOrderService/GetOrderDetailsByIdResponse")]
        WebStore.WebUi.OrderService.OrderDetailsDataContract GetOrderDetailsById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrderDetailsById", ReplyAction="http://tempuri.org/IOrderService/GetOrderDetailsByIdResponse")]
        System.Threading.Tasks.Task<WebStore.WebUi.OrderService.OrderDetailsDataContract> GetOrderDetailsByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/UpdateOrderDetails", ReplyAction="http://tempuri.org/IOrderService/UpdateOrderDetailsResponse")]
        void UpdateOrderDetails(WebStore.WebUi.OrderService.OrderDetailsDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/UpdateOrderDetails", ReplyAction="http://tempuri.org/IOrderService/UpdateOrderDetailsResponse")]
        System.Threading.Tasks.Task UpdateOrderDetailsAsync(WebStore.WebUi.OrderService.OrderDetailsDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/DeleteOrderDetails", ReplyAction="http://tempuri.org/IOrderService/DeleteOrderDetailsResponse")]
        void DeleteOrderDetails(WebStore.WebUi.OrderService.OrderDetailsDataContract order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/DeleteOrderDetails", ReplyAction="http://tempuri.org/IOrderService/DeleteOrderDetailsResponse")]
        System.Threading.Tasks.Task DeleteOrderDetailsAsync(WebStore.WebUi.OrderService.OrderDetailsDataContract order);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderServiceChannel : WebStore.WebUi.OrderService.IOrderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderServiceClient : System.ServiceModel.ClientBase<WebStore.WebUi.OrderService.IOrderService>, WebStore.WebUi.OrderService.IOrderService {
        
        public OrderServiceClient() {
        }
        
        public OrderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddOrder(WebStore.WebUi.OrderService.OrderDataContract order) {
            base.Channel.AddOrder(order);
        }
        
        public System.Threading.Tasks.Task AddOrderAsync(WebStore.WebUi.OrderService.OrderDataContract order) {
            return base.Channel.AddOrderAsync(order);
        }
        
        public WebStore.WebUi.OrderService.OrderDataContract[] GetOrders() {
            return base.Channel.GetOrders();
        }
        
        public System.Threading.Tasks.Task<WebStore.WebUi.OrderService.OrderDataContract[]> GetOrdersAsync() {
            return base.Channel.GetOrdersAsync();
        }
        
        public WebStore.WebUi.OrderService.OrderDataContract GetOrderById(int id) {
            return base.Channel.GetOrderById(id);
        }
        
        public System.Threading.Tasks.Task<WebStore.WebUi.OrderService.OrderDataContract> GetOrderByIdAsync(int id) {
            return base.Channel.GetOrderByIdAsync(id);
        }
        
        public void UpdateOrder(WebStore.WebUi.OrderService.OrderDataContract order) {
            base.Channel.UpdateOrder(order);
        }
        
        public System.Threading.Tasks.Task UpdateOrderAsync(WebStore.WebUi.OrderService.OrderDataContract order) {
            return base.Channel.UpdateOrderAsync(order);
        }
        
        public void DeleteOrder(WebStore.WebUi.OrderService.OrderDataContract order) {
            base.Channel.DeleteOrder(order);
        }
        
        public System.Threading.Tasks.Task DeleteOrderAsync(WebStore.WebUi.OrderService.OrderDataContract order) {
            return base.Channel.DeleteOrderAsync(order);
        }
        
        public void AddOrderDetails(WebStore.WebUi.OrderService.OrderDetailsDataContract[] order) {
            base.Channel.AddOrderDetails(order);
        }
        
        public System.Threading.Tasks.Task AddOrderDetailsAsync(WebStore.WebUi.OrderService.OrderDetailsDataContract[] order) {
            return base.Channel.AddOrderDetailsAsync(order);
        }
        
        public WebStore.WebUi.OrderService.OrderDetailsDataContract[] GetOrderDetails() {
            return base.Channel.GetOrderDetails();
        }
        
        public System.Threading.Tasks.Task<WebStore.WebUi.OrderService.OrderDetailsDataContract[]> GetOrderDetailsAsync() {
            return base.Channel.GetOrderDetailsAsync();
        }
        
        public WebStore.WebUi.OrderService.OrderDetailsDataContract GetOrderDetailsById(int id) {
            return base.Channel.GetOrderDetailsById(id);
        }
        
        public System.Threading.Tasks.Task<WebStore.WebUi.OrderService.OrderDetailsDataContract> GetOrderDetailsByIdAsync(int id) {
            return base.Channel.GetOrderDetailsByIdAsync(id);
        }
        
        public void UpdateOrderDetails(WebStore.WebUi.OrderService.OrderDetailsDataContract order) {
            base.Channel.UpdateOrderDetails(order);
        }
        
        public System.Threading.Tasks.Task UpdateOrderDetailsAsync(WebStore.WebUi.OrderService.OrderDetailsDataContract order) {
            return base.Channel.UpdateOrderDetailsAsync(order);
        }
        
        public void DeleteOrderDetails(WebStore.WebUi.OrderService.OrderDetailsDataContract order) {
            base.Channel.DeleteOrderDetails(order);
        }
        
        public System.Threading.Tasks.Task DeleteOrderDetailsAsync(WebStore.WebUi.OrderService.OrderDetailsDataContract order) {
            return base.Channel.DeleteOrderDetailsAsync(order);
        }
    }
}
