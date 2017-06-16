﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasperInc.MainSite.Service.Data.DataModels
{

	public class NarrativeDataModel
	{

		public NarrativeDataModel() { }

		[Key]
		[RequiredAttribute]
		public Guid Id { get; set; }
		[RequiredAttribute]
		public string Title { get; set; }
		[RequiredAttribute]
		public string Description { get; set; }
		[RequiredAttribute]
		public string BodyHtml { get; set; }
		[RequiredAttribute]
		public DateTime CreatedOn { get; set; }
		[RequiredAttribute]
		public DateTime UpdatedOn { get; set; }

		// Narrative tags
		public virtual List<NarrativeTagDataModel> NarrativeTags { get; set; }

	}
}