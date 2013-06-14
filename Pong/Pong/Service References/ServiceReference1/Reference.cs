﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pong.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Highscore", Namespace="http://schemas.datacontract.org/2004/07/PongHighscoreService")]
    [System.SerializableAttribute()]
    public partial class Highscore : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HitsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ScoreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Hits {
            get {
                return this.HitsField;
            }
            set {
                if ((this.HitsField.Equals(value) != true)) {
                    this.HitsField = value;
                    this.RaisePropertyChanged("Hits");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Score {
            get {
                return this.ScoreField;
            }
            set {
                if ((this.ScoreField.Equals(value) != true)) {
                    this.ScoreField = value;
                    this.RaisePropertyChanged("Score");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IPongHighscores")]
    public interface IPongHighscores {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPongHighscores/SendHighscore", ReplyAction="http://tempuri.org/IPongHighscores/SendHighscoreResponse")]
        void SendHighscore(int score, string name, int hits);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPongHighscores/GetHighestScores", ReplyAction="http://tempuri.org/IPongHighscores/GetHighestScoresResponse")]
        Pong.ServiceReference1.Highscore[] GetHighestScores();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPongHighscoresChannel : Pong.ServiceReference1.IPongHighscores, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PongHighscoresClient : System.ServiceModel.ClientBase<Pong.ServiceReference1.IPongHighscores>, Pong.ServiceReference1.IPongHighscores {
        
        public PongHighscoresClient() {
        }
        
        public PongHighscoresClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PongHighscoresClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PongHighscoresClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PongHighscoresClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SendHighscore(int score, string name, int hits) {
            base.Channel.SendHighscore(score, name, hits);
        }
        
        public Pong.ServiceReference1.Highscore[] GetHighestScores() {
            return base.Channel.GetHighestScores();
        }
    }
}