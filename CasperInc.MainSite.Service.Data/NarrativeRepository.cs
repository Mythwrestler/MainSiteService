using System;
using System.Collections.Generic;
using System.Linq;
using CasperInc.MainSite.Service.Data.DataModels;
using CasperInc.MainSite.Service.Models;
using Microsoft.Extensions.Logging;

namespace CasperInc.MainSite.Service.Data.DbContexts
{
    public class NarrativeRepository
    {

        private NarrativeDbContext _dbContext;
        private ILogger _logger;

        public NarrativeRepository(NarrativeDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        public List<Narrative> getNarrativeList()
        {

            var narrativesFromContext = _dbContext.NarrativeData.ToArray();
            var narrativeList = ToNarrativeList(narrativesFromContext);

            return narrativeList;
        }

        public Narrative getNarrative(Guid narrativeId)
        {

            var narrativeFromContext = _dbContext.NarrativeData.Where(n => n.Id == narrativeId).First();
            Narrative narrative = null;

            if(narrativeFromContext != null)
            {
                narrative = ToNarrative(narrativeFromContext);
            }


            return new Narrative();
        }


        private Narrative ToNarrative (NarrativeDataModel narrativeFromSource )
        {
            
            Narrative narrative = null;

            try
            {
                narrative = new Narrative()
                {
                    Id = narrativeFromSource.Id,
                    Title = narrativeFromSource.Title,
                    Description = narrativeFromSource.Description,
                    BodyHtml = narrativeFromSource.BodyHtml
                };
            }
            catch (Exception e)
            {
                _logger.LogWarning(300,e,$"Conversion from NarrativeDataModel to Narrative failed. NarrativeDataModel");
            }

            return narrative;
        }

        private List<Narrative> ToNarrativeList(IEnumerable<NarrativeDataModel> narrativeListing)
        {
            if (narrativeListing == null) throw new NullReferenceException();

            var narrativeList = new List<Narrative>();

            try
            {
                foreach (var narrative in narrativeListing)
                {
                    try
                    {
                        narrativeList.Add(
                            new Narrative()
                            {
                                Id = narrative.Id,
                                Title = narrative.Title,
                                Description = narrative.Description
                            }
                        );
                        _logger.LogTrace(100,$"NarrativeDataModel successfully converted to Narrative. NarrativeDataModel Id: {narrative.Id}");
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning(300, e, $"Conversion of NarrativeDataModel to Narrative failed. NarrativeDataModel Id: {narrative.Id}");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(300,e,$"Conversion of IEnumerable<NarrativeDataModel> to List<Narrative> failed.");
            }

            _logger.LogTrace(100,$"{narrativeListing.Count()} NarrativeDataModel objects converted to {narrativeList.Count()} Narrative Objects.");

            return narrativeList;

        }

    }

}
