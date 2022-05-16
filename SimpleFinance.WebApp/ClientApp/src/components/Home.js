import React, { Component } from 'react';
import { Wallets } from './Wallets';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <Wallets />
      </div>
    );
  }
}
