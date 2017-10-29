import React, { Component } from 'react';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: true,
    };
  }

  componentDidMount = () => {
    this.fetchDashboardData();
  };

  fetchDashboardData = () => {
    fetch('/api/v1/race/all')
    .then(res => res.json())
    .then(raceData => {
       this.setState({raceDetails : raceData }); 
       this.setState({ loadingError:false });
       this.setState({ isLoading: false });
    }).catch((error) => { 
        this.setState({ loadingError:true });
        this.setState({ isLoading: false });
    });
  }

  render() {
    const horseDetails = horses => (
      <div className="race-horse-details-container">
        <table>
          <col className="column-one" />
          <col className="column-two" />
          <col className="column-three" />
          <thead>
            <tr>
              <th>{'Horse Name'}</th>
              <th>{'Bets'}</th>
              <th>{'Est. Payout'}</th>
            </tr>
          </thead>
          <tbody>
            {horses.map(horse => (
              <tr key={horse.HorseId}>
                <td>{horse.HorseName}</td>
                <td>{horse.BetCount}</td>
                <td>${horse.EstimatedPayout}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );

    const status = raceStatus => {
      if(raceStatus === 'Completed')
        return 'status-completed';
      if(raceStatus === 'InProgress')
        return 'status-inprogress';
      
      return 'status-pending';
    };

    const raceDetails = this.state.raceDetails && this.state.raceDetails.RaceDetails.map(race => (
      <div className="race-details" key={race.RaceId}>
        <div className="race-header">
          {race.RaceName} - <span className={status(race.RaceStatus)}>{race.RaceStatus}</span> - ${race.TotalBets}
        </div>
        {horseDetails(race.HorseDetails)}
      </div>
    ));
    return (
      <div>
        <div className="header">{'Race Day'}</div>
        {this.state.loadingError && (
          <div className="loading-error">{'Oops!! Something went wrong, please visit after sometime...'}</div>
        )}
        {this.state.isLoading && (
          <div className="loading-inprogress">{'Please wait, preparing your dashboard...'}</div>
        )}
        {!this.state.loadingError &&
          !this.state.isLoading && (
            <div className="race-container">{raceDetails}</div>
          )}
      </div>
    );
  }
}

export default App;
