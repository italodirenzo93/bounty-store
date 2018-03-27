<template>
    <div class="container">
        <bounty v-for="bounty in bounties" :key="bounty.id" :bounty="bounty" class="column is-4"></bounty>
    </div>
</template>

<script>
import Bounty from './Bounty';
import {apiEndpoint} from '../config';

export default {
    components: {
        Bounty
    },
    data() {
        return {
            bounties: []
        };
    },
    created() {
        fetch(apiEndpoint).then(res => res.json()).then(json => this.bounties = json);
    }
};
</script>

<style>
.bounty-list {
    display: block;
    margin: auto;
    max-width: 800px;
}
</style>