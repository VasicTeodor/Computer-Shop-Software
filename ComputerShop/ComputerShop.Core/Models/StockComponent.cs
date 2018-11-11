///////////////////////////////////////////////////////////
//  StockComponent.cs
//  Implementation of the Class StockComponent
//  Generated by Enterprise Architect
//  Created on:      06-avg-2018 18.29.40
//  Original author: sasa.devic
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.Serialization;
using ComputerShop.Core.Models;

namespace ComputerShop.Core {
    [DataContract]
	public class StockComponent : StockComponentPrototype,INotifyPropertyChanged {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private Guid _id;
		private int _count;
		private string _physicalLocation;
		public Component m_Component;

        public event PropertyChangedEventHandler PropertyChanged;
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string PhysicalLocation { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public Component M_Component { get; set; }
        public StockComponent(){

		}

		~StockComponent(){

		}

        public override StockComponentPrototype Clone()
        {
            StockComponent newStockComponent = new StockComponent
            {
                Count = this.Count,
                M_Component = this.M_Component,
                PhysicalLocation = this.PhysicalLocation,
                Type = this.Type
            };

            return newStockComponent;
        }
    }//end StockComponent

}//end namespace comppkg