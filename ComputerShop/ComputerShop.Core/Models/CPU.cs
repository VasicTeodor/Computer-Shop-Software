///////////////////////////////////////////////////////////
//  CPU.cs
//  Implementation of the Class CPU
//  Generated by Enterprise Architect
//  Created on:      06-avg-2018 18.29.40
//  Original author: sasa.devic
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace ComputerShop.Core
{
    [DataContract]
	public class CPU : Component {
        [DataMember]
        public String Speed { get; set; }
        [DataMember]
        public Int32 Cores { get; set; }
		public CPU(){

		}
        
		~CPU(){

		}

	}//end CPU

}//end namespace comppkg