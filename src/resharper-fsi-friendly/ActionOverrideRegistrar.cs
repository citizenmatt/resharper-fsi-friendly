using JetBrains.ActionManagement;
using JetBrains.DataFlow;
using JetBrains.ProjectModel;
using JetBrains.VsIntegration.ActionManagement;
using Microsoft.VisualStudio.Shell.Interop;

namespace CitizenMatt.ReSharper.FsiFriendly
{
  [SolutionComponent]
  public class ActionOverrideRegistrar
  {
    public ActionOverrideRegistrar(Lifetime lifetime, IActionManager actionManager, VsActionManager vsActionManager, IVsCmdNameMapping vsCmdNameMapping)
    {
      AddOverridingHandler(lifetime, actionManager, "QuickFix", new FsiFriendlyQuickFixActionHandler(vsActionManager, vsCmdNameMapping));
    }

    private void AddOverridingHandler(Lifetime lifetime, IActionManager actionManager, string actionId, IActionHandler actionHandler)
    {
      var action = actionManager.TryGetAction(actionId) as IUpdatableAction;
      if (action != null)
        action.AddHandler(lifetime, actionHandler);
    }
  }
}