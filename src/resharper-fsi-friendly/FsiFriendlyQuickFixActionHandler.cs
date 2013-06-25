using System;
using System.Linq;
using JetBrains.ActionManagement;
using JetBrains.Application.DataContext;
using JetBrains.ProjectModel;
using JetBrains.VsIntegration.ActionManagement;
using Microsoft.VisualStudio.Shell.Interop;

namespace CitizenMatt.ReSharper.FsiFriendly
{
  public class FsiFriendlyQuickFixActionHandler : IActionHandler
  {
    private const string ExecuteInInteractive = "EditorContextMenus.CodeWindow.ExecuteInInteractive";

    private static readonly string[] FileTypes = { ".fs", ".fsi", ".fsx" };

    private readonly VsActionManager vsActionManager;
    private readonly IVsCmdNameMapping vsCmdNameMapping;

    public FsiFriendlyQuickFixActionHandler(VsActionManager vsActionManager, IVsCmdNameMapping vsCmdNameMapping)
    {
      this.vsActionManager = vsActionManager;
      this.vsCmdNameMapping = vsCmdNameMapping;
    }

    public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
    {
      return IsFSharpFile(context) || nextUpdate();
    }

    public void Execute(IDataContext context, DelegateExecute nextExecute)
    {
      if (IsFSharpFile(context))
      {
        var commandId = VsCommandHelpers.TryMapVsCommandNameToVsCommandID(ExecuteInInteractive, vsCmdNameMapping);
        if (commandId != null)
        {
          vsActionManager.ExecuteVsCommand(commandId);
          return;
        }
      }
      nextExecute();
    }

    private bool IsFSharpFile(IDataContext context)
    {
      var projectFile =
        context.GetData(JetBrains.ProjectModel.DataContext.DataConstants.PROJECT_MODEL_ELEMENT) as IProjectFile;
      return projectFile != null && IsFSharpFile(projectFile.Name);
    }

    private bool IsFSharpFile(string name)
    {
      return FileTypes.Any(fileType => name.EndsWith(fileType, StringComparison.OrdinalIgnoreCase));
    }
  }
}