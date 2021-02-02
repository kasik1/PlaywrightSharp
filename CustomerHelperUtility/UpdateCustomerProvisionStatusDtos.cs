using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static CustomerHelperUtility.EnumeratorsEntity;

namespace CustomerHelperUtility
{
    public static class EnumeratorsEntity
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ProvisionStatuses
        {
            Pending, InProcess, Failed, Completed
        }

        /// <summary>
        /// Operation types
        /// </summary>
        public enum OperationTypes { Create, Update, Disable }
    }
    /// <summary>
    /// Represent a read customer dto
    /// </summary>
    public class ReadCustomerDto
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <example>""9efdea9d-b38c-4282-85fc-5cfeb8143217"</example>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// <example>"customer name"</example>
        public string Name { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        /// <example>true</example>
        public bool Enabled { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        /// <example>"customer description"</example>
        public string Description { get; set; }

        /// <summary>
        /// Line of Business
        /// </summary>
        /// <example>"customer lob"</example>
        public string LineOfBusiness { get; set; }

        /// <summary>
        /// Encoded 64 string that represents an icon
        /// </summary>
        /// <example>"http://icon"</example>
        public string IconUrl { get; set; }

        /// <summary>
        /// Customer portal url
        /// </summary>
        public string PortalUrl { get; set; }

        /// <summary>
        /// creation date time
        /// </summary>
        /// <example>"2019-07-15T22:58:53.939Z"</example>
        public DateTimeOffset CreateDateTime { get; set; }

        /// <summary>
        /// Created by
        /// </summary>
        /// <example>"2019-07-15T22:58:53.939Z"</example>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date customer infrastructure was provision
        /// </summary>
        /// <example>"2019-07-15T22:58:53.939Z</example>
        public DateTimeOffset? ProvisionStartDateTime { get; set; }

        /// <summary>
        /// Date customer infrastructure provision was completed
        /// </summary>
        /// <example>"2019-07-15T22:58:53.939Z</example>
        public DateTimeOffset? ProvisionEndDateTime { get; set; }

        /// <summary>
        /// Provision TriggerStatus
        /// </summary>
        public ProvisionStatuses ProvisionStatus { get; set; }

        /// <summary>
        /// Provision error in case provision failure, hold last error
        /// </summary>
        /// <example>"provision error"</example>
        public string ProvisionError { get; set; }

        /// <summary>
        /// Provision Pipeline Id
        /// </summary>
        /// <example>"12225ab"</example>
        public string ProvisionPipelineId { get; set; }

        /// <summary>
        /// Infrastructure Attributes
        /// </summary>
        public List<CustomAttributeDto> InfrastructureAttributes { get; set; }

        /// <summary>
        /// List of business process for the customer
        /// </summary>
        public List<ReadBusinessProcessDto> BusinessProcesses { get; set; }

        /// <summary>
        /// Total Blueprints
        /// </summary>
        public int TotalBluePrintsObjects { get; set; }

        /// <summary>
        /// Total Releases
        /// </summary>
        public int TotalReleases { get; set; }

        /// <summary>
        /// Total Configurations
        /// </summary>
        public int TotalConfigurations { get; set; }


    }

    /// <summary>
    /// Represent a business process read dto
    /// </summary>
    public class ReadBusinessProcessDto
    {
        /// <summary>
        /// Business Process id
        /// </summary>
        /// <example>"2d4c765b-509e-46d8-9ab4-ac0d70db11bb"</example>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// <example>"my business process"</example>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        /// <example>"my business process description"</example>
        public string Description { get; set; }

        /// <summary>
        /// Created by
        /// </summary>
        /// <example>"user@conduent.com"</example>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Creation Date Time
        /// </summary>
        /// <example>"2019-07-15T22:23:11.308Z"</example>
        public DateTimeOffset CreationDateTime { get; set; }

        /// <summary>
        /// Change Log
        /// </summary>
        public List<ReadChangeLogDto> Changelog { get; set; }


        /// <summary>
        /// Business Process Custom attributes
        /// </summary>
        public List<CustomAttributeDto> CustomAttributes { get; set; }

        /// <summary>
        /// Enable
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Total Blueprints
        /// </summary>
        public int TotalBluePrintsObjects { get; set; }

        /// <summary>
        /// Total Releases
        /// </summary>
        public int TotalReleases { get; set; }

        /// <summary>
        /// Total Configurations
        /// </summary>
        public int TotalConfigurations { get; set; }

    }

    /// <summary>
    /// Represent a change log read dto
    /// </summary>
    public class ReadChangeLogDto
    {

        /// <summary>
        /// User Id
        /// </summary>
        /// <example>"user@conduent.com"</example>
        public string UserId { get; set; }

        /// <summary>
        /// Date time
        /// </summary>
        /// <example>"2019-07-15T22:23:11.308Z"</example>
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        /// Operation Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumeratorsEntity.OperationTypes OperationType { get; set; }
    }

    /// <summary>
    /// Represent a write dto for infrastructure attribute
    /// </summary>
    public class CustomAttributeDto
    {
        /// <summary>
        /// key
        /// </summary>
        /// <example>"myKey"</example>
        [JsonRequired]
        public string Key { get; set; }

        /// <summary>
        /// value
        /// </summary>
        /// /// <example>"myValue"</example>
        [JsonRequired]
        public string Value { get; set; }

    }

    public class WriteProvisionStatusDto
    {
        /// <summary>
        /// Pipeline Id
        /// </summary>
        /// <example>"1225AB"</example>
        [JsonRequired]
        public string PipelineId { get; set; }

        /// <summary>
        /// TriggerStatus of the provision
        /// </summary>
        /// <example>"Building"</example>
        [JsonRequired]
        public ProvisionStatuses Status { get; set; }

        /// <summary>
        /// Error Message if status is failed
        /// </summary>
        /// <example>"error message"</example>
        ////[RequiredIf("Status", ProvisionStatuses.Failed, "Error is Required if status is Failed")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Infrastructure Attributes
        /// </summary>
        public List<CustomAttributeDto> InfrastructureAttributes { get; set; }

        /// <summary>
        /// Customer portal url
        /// </summary>
        public string PortalUrl { get; set; }
    }
}
