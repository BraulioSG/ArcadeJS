import { Route, Switch } from "wouter";
import Login from "./Views/Login";
import './App.scss'

function App() {

  return (
    <>
        <Switch>
            <Route path="/">
                <h1> Home page </h1>
            </Route>
            <Route path="/(login|signup)" component={Login}/>
        </Switch>
    </>
  )
}

export default App
