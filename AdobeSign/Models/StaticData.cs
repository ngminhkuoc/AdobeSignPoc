namespace AdobeSign.Models
{
    class StaticData
    {
        public class Event
        {
            public const string AgreementCreated = "AGREEMENT_CREATED";
            public const string AgreementActionDelegated = "AGREEMENT_ACTION_DELEGATED";
            public const string AgreementRecalled = "AGREEMENT_RECALLED";
            public const string AgreementRejected = "AGREEMENT_REJECTED";
            public const string AgreementExpired = "AGREEMENT_EXPIRED";
            public const string AgreementActionCompleted = "AGREEMENT_ACTION_COMPLETED";
            public const string AgreementWorkflowCompleted = "AGREEMENT_WORKFLOW_COMPLETED";
            public const string AgreementEmailViewed = "AGREEMENT_EMAIL_VIEWED";
            public const string AgreementModified = "AGREEMENT_MODIFIED";
            public const string AgreementShared = "AGREEMENT_SHARED";
            public const string AgreementReadyToVault = "AGREEMENT_READY_TO_VAULT";
            public const string AgreementVaulted = "AGREEMENT_VAULTED";
            public const string AgreementActionRequested = "AGREEMENT_ACTION_REQUESTED";
            public const string AgreementActionReplacedSigner = "AGREEMENT_ACTION_REPLACED_SIGNER";
            public const string AgreementAutoCancelledConversionProblem = "AGREEMENT_AUTO_CANCELLED_CONVERSION_PROBLEM";
            public const string AgreementDocumentsDeleted = "AGREEMENT_DOCUMENTS_DELETED";
            public const string AgreementEmailBounced = "AGREEMENT_EMAIL_BOUNCED";
            public const string AgreementKbaAuthenticated = "AGREEMENT_KBA_AUTHENTICATED";
            public const string AgreementOfflineSync = "AGREEMENT_OFFLINE_SYNC";
            public const string AgreementUserAckAgreementModified = "AGREEMENT_USER_ACK_AGREEMENT_MODIFIED";
            public const string AgreementUploadedBySender = "AGREEMENT_UPLOADED_BY_SENDER";
            public const string AgreementWebIdentityAuthenticated = "AGREEMENT_WEB_IDENTITY_AUTHENTICATED";
            public const string AgreementAll = "AGREEMENT_ALL";
            //['MEGASIGN_CREATED' or 'MEGASIGN_RECALLED' or 'MEGASIGN_SHARED' or 'MEGASIGN_ALL' or 'WIDGET_CREATED' or 'WIDGET_MODIFIED' or 'WIDGET_SHARED' or 'WIDGET_ENABLED' or 'WIDGET_DISABLED' or 'WIDGET_AUTO_CANCELLED_CONVERSION_PROBLEM' or 'WIDGET_ALL' or 'LIBRARY_DOCUMENT_CREATED' or 'LIBRARY_DOCUMENT_AUTO_CANCELLED_CONVERSION_PROBLEM' or 'LIBRARY_DOCUMENT_MODIFIED' or 'LIBRARY_DOCUMENT_ALL
        }
        public class Role
        {
            public const string Signer = "SIGNER";
            public const string Approver = "APPROVER";
            public const string Acceptor = "ACCEPTOR";
            public const string CertifiedRecipient = "CERTIFIED_RECIPIENT";
            public const string FormFiller = "FORM_FILLER";
            public const string DelegateToSigner = "DELEGATE_TO_SIGNER";
            public const string DelegateToApprover = "DELEGATE_TO_APPROVER";
            public const string DelegateToAcceptor = "DELEGATE_TO_ACCEPTOR";
            public const string DelegateToCertifiedRecipient = "DELEGATE_TO_CERTIFIED_RECIPIENT";
            public const string DelegateToFormFiller = "DELEGATE_TO_FORM_FILLER";
            public const string Share = "SHARE";
        }

        public class Scope
        {
            public const string Account = "ACCOUNT";
            public const string Group = "GROUP";
            public const string User = "USER";
            public const string Resource = "RESOURCE";
        }

        public class State
        {
            public const string Authoring = "AUTHORING";
            public const string Draft = "DRAFT";
            public const string InProgress = "IN_PROCESS";
        }

        public class SignatureType
        {
            public const string ESign = "ESIGN";
            public const string Written = "WRITTEN";
        }
    }
}
