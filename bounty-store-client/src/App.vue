<template>
	<div id="app">
		<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
			<router-link to="/" class="navbar-brand">The Bounty Store</router-link>
			<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			</button>

			<div class="collapse navbar-collapse" id="navbarSupportedContent">
				<ul class="navbar-nav mr-auto">
					<li class="nav-item">
						<router-link to="/new" class="nav-link">Post Bounty</router-link>
					</li>
				</ul>
			</div>
		</nav>

		<router-view></router-view>
	</div>
</template>

<script>
export default {

};
</script>

<style>
body {
	font-family: "Raleway", sans-serif;
	background-image: url("assets/tileable_wood_texture.png");
	background-repeat: repeat;
}
h1,h2,h3,h4,h5,h6,.navbar-brand {
	font-family: "Smokum", serif;
}
</style>
