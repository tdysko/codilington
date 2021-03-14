import { Component } from '@angular/core';
import { EnumToArrayPipe } from '../../pipes/enumToArray';
import { codingChallenge, submission } from '../../models/Submissions';
import { SubmissionService } from '../../services/submission.service';
import { CodingChallengesService } from '../../services/coding-challenges.service';
import { LanguagesService } from '../../services/languages.service';
import { Language } from '../../models/Languages';
import { forkJoin } from 'rxjs';
import { map, takeUntil, delay, tap } from 'rxjs/operators';

@Component({
  selector: 'app-solver-component',
  providers: [EnumToArrayPipe],
  templateUrl: './solver.component.html'
})
export class SolverComponent {

  submission: submission = {
    Name: '',
    Solution: 'Microsoft (R) Visual C# Compiler version 2.9.0.63208 (958f2354)\n\nusing System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text.RegularExpressions;\n\nnamespace Rextester\n{\n    public class Program\n    {\n        public static void Main(string[] args)\n        {\n            //Your code goes here\n            Console.WriteLine(\"Hello, world!\");\n        }\n    }\n}',
    IdCodingChallenges: 0,
    Language: 0
  };
  codingChallenges: codingChallenge[];
  languages: Language[];

  private destroyed$: any;

  constructor(
    private submissionsService: SubmissionService,
    private codingChallengesService: CodingChallengesService,
    private languagesService: LanguagesService) {

    this.codingChallengesService.get().subscribe(result => {
      this.codingChallenges = result;
    }, error => console.error(error));

    this.languagesService.get().subscribe(result => {
      this.languages = result;
    }, error => console.error(error));
  }

  isFormValid() {
    return this.submission.Name.trim().length > 0 &&
      this.submission.Solution.trim().length > 0 &&
      this.codingChallenges.map(p => p.id).includes(this.submission.IdCodingChallenges) &&
      this.languages.map(p => p.Id).includes(this.submission.Language);
  }

  submit() {
    if (this.isFormValid()) {
      this.submissionsService.runSubmission(this.submission).subscribe(result=> console.log(result), error => console.log(error));
      this.submissionsService.postSubmission(this.submission).subscribe(result => alert('Submission saved succesfuly'), error => console.error(error));
    }
  }

  onDestroy() {
    this.destroyed$.next(true);
    this.destroyed$.complete();
  }
}
