using System;
using System.Collections.Generic;
using System.Text;

namespace UndoAssessment.ViewModels
{
    public static class AssessmentContextViewModel
    {
        private static AssessmentViewModel _assessmentViewModel = new AssessmentViewModel();
        public static AssessmentViewModel AssessmentViewModel
        {
            get
            {
                return _assessmentViewModel;
            }
        }
    }
}
