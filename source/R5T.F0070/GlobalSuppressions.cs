// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

using R5T.Z0016;


[assembly: SuppressMessage("Design", "CA1050:Declare types in namespaces", Justification = IJustifications.ExtensionsCanBeWithoutNamespaces_Constant)]
[assembly: SuppressMessage("Usage", "CA2254:Template should be a static expression", Justification = IJustifications.LoggingTemplatesCanBeDynamic_Constant)]
