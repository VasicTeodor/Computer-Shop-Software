///////////////////////////////////////////////////////////
//  Case.cs
//  Implementation of the Class Case
//  Generated by Enterprise Architect
//  Created on:      06-avg-2018 23.01.24
//  Original author: Teodor Vasi�
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace ComputerShop.Core
{
    [DataContract]
	public class Case : Component {
        [DataMember]
        public String CaseType { get; set; }

		public Case(){

		}

		~Case(){

		}

	}//end Case

}//end namespace comppkg