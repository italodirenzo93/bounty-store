<template>
	<div id="app">
		<nav class="navbar is-dark" role="navigation" aria-label="main navigation">
			<div class="navbar-brand">
				<a class="navbar-item" href="/">
					<img src="https://bulma.io/images/bulma-logo-white.png" alt="Bulma: a modern CSS framework based on Flexbox" width="112" height="28">
				</a>

				<div class="navbar-burger">
					<span></span>
					<span></span>
					<span></span>
				</div>
			</div>

			<div class="navbar-start">
				<router-link to="/" class="navbar-item">Home</router-link>
				<router-link to="/bounties" class="navbar-item">Bounties</router-link>
			</div>
		</nav>

		<router-view></router-view>
	</div>
</template>

<script>
import 'bulma/css/bulma.css';

export default {

};
</script>

<style>

</style>
