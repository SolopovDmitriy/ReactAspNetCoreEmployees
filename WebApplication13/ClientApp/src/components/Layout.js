import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

import MainMenu  from './MainMenu/MainMenu';
import Footer from './Footer/Footer';


export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <MainMenu />
        <Container>
          {this.props.children}
        </Container>
        <Footer />

      </div>
    );
  }
}
