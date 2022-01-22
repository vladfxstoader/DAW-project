import { Component, Input, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit {

  @Input() messageFromParent: any;
  @Output() messageFromChild = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
    console.log(this.messageFromParent);
  }

  public emitData(): void {
    this.messageFromChild.emit('message from Child');
  }
}
