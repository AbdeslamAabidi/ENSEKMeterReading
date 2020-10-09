import { Component, ViewChild } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {

  public uploadingStatus: string = "";
  //public errors: string[] = [];

  private meterReading: MeterReading[];
  public csvFile: any;

  public meterReadingReport: MeterReadingReport;

  private readonly apiUrl: string = "https://localhost:44372/api/MeterReading";

  @ViewChild('csvReader', { static: false }) csvReader: any;

  constructor(private http: HttpClient) {
    this.meterReadingReport = new MeterReadingReport();
    this.meterReadingReport.successfull = [];
    this.meterReadingReport.failed      = [];
  }

  setCSV($event: any) {
    this.csvFile = $event;
    this.uploadingStatus = "";
  }

  getMeterReadingReport(entity: MeterReading[]): Observable<any> {
    return this.http.post<MeterReading[]>(this.apiUrl, this.meterReading, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  uploadCSV(): void {
    this.uploadingStatus = "UPLOADING...";
    let files = this.csvFile.srcElement.files;

    if (this.isValidCSVFile(files[0])) {

      let input = this.csvFile.target;
      let reader = new FileReader();
      reader.readAsText(input.files[0]);

      reader.onload = () => {

        let csvData = reader.result;
        let csvRecordsArray = (<string>csvData).split(/\r\n|\n/);
        let headersRow = this.getHeaderArray(csvRecordsArray);
        this.getDataRecordsArrayFromCSVFile(csvRecordsArray, headersRow.length);
        
        this.getMeterReadingReport(this.meterReading).subscribe({
          next: _meterReadingReport => {
            console.log(_meterReadingReport);
            this.meterReadingReport = <MeterReadingReport>_meterReadingReport;
            this.uploadingStatus = "FINISHED";
          },
          error: err => {
            console.log("ERROR:" + err);
          }
        });
        
        this.fileReset();
      };

      reader.onerror = function () {
        console.log('error is occured while reading file!');
      };

    } else {
      alert("Please import valid .csv file.");
      this.fileReset();
    }
  }

  getDataRecordsArrayFromCSVFile(csvRecordsArray: any, headerLength: any) {
    this.meterReading = [];
    for (let i = 1; i < csvRecordsArray.length; i++) {
      let curruntRecord = (<string>csvRecordsArray[i]).split(',');
      let csvRecord = new MeterReading();
      if (curruntRecord.length >= headerLength) {
        csvRecord.accountId = Number(curruntRecord[0].trim());
        csvRecord.meterReadingDateTime = this.strToDate(curruntRecord[1].trim());
        csvRecord.meterReadValue = curruntRecord[2].trim();
        this.meterReading.push(csvRecord);
      }
    }
  }

  strToDate(dtStr: any): Date {
    let dateParts = dtStr.split("/");
    let timeParts = dateParts[2].split(" ")[1].split(":");
    dateParts[2] = dateParts[2].split(" ")[0];

    return new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0], timeParts[0], timeParts[1]); 
  }

  isValidCSVFile(file: any) {
    return file.name.endsWith(".csv");
  }

  getHeaderArray(csvRecordsArr: any) {
    let headers = (<string>csvRecordsArr[0]).split(',');
    let headerArray = [];
    for (let j = 0; j < headers.length; j++) {
      headerArray.push(headers[j]);
    }
    return headerArray;
  }

  fileReset() {
    this.csvReader.nativeElement.value = "";
    this.meterReading = [];
  }

  private handleError(err: HttpErrorResponse) {

    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }

}

class MeterReading {
  accountId: number;
  meterReadingDateTime: Date;
  meterReadValue: string;
}

class MeterReadingErrorMessages
{
    AccountId: number
    MeterReadingDateTime: Date
    MeterReadValue: string
    Messages: string
}

class MeterReadingReport
{
    successfull: MeterReadingErrorMessages[];
    failed: MeterReadingErrorMessages[];
}
