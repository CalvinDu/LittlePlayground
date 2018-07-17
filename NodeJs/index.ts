'use strict'

const http = require('http');

const hostname = '127.0.0.1';
const port = 3000;

const server = http.createServer((req, res) => {
  res.statusCode = 200;
  res.setHeader('Content-Type', 'text/plain');
  res.end('Hello World\n');
});

export interface ITest {
  attr1?: string | undefined;
  attr2?: number | undefined;
}

export class Test implements ITest {
  attr1: string | undefined = 'haha';  
  attr2: number | undefined = 322;

  constructor (input?: ITest) {
    if( input ) {
      for (let property in input){
        if ( input.hasOwnProperty(property)) {
          (<any>this)[property] = (<any>input)[property];
        }
      }
    }
  }

}

const test = new Test({attr1:'hehe'});

server.listen(port, hostname, () => {
  console.log(`${test.attr1}  ${test.attr2}`);
  console.log(`Server running at http://${hostname}:${port}/`);
});